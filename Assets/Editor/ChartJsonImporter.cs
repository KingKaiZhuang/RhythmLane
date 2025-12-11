using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class JsonNote
{
    public float time;
    public int lane;
}

[Serializable]
public class JsonChart
{
    public List<JsonNote> notes;
}

#if UNITY_EDITOR
public class ChartJsonImporter : EditorWindow
{
    public TextAsset jsonFile;
    public NoteChart targetChart;
    public MusicData musicData;

    [MenuItem("RhythmTools/Import Chart From JSON")]
    public static void ShowWindow()
    {
        GetWindow<ChartJsonImporter>("Chart JSON Importer");
    }

    void OnGUI()
    {
        GUILayout.Label("匯入 JSON 譜面到 NoteChart", EditorStyles.boldLabel);

        jsonFile = (TextAsset)EditorGUILayout.ObjectField("JSON File", jsonFile, typeof(TextAsset), false);
        musicData = (MusicData)EditorGUILayout.ObjectField("MusicData", musicData, typeof(MusicData), false);
        targetChart = (NoteChart)EditorGUILayout.ObjectField("Target NoteChart", targetChart, typeof(NoteChart), false);

        if (GUILayout.Button("Import") && jsonFile != null && targetChart != null)
        {
            ImportJson();
        }
    }

    void ImportJson()
    {
        try
        {
            JsonChart jsonChart = JsonUtility.FromJson<JsonChart>(jsonFile.text);
            if (jsonChart == null || jsonChart.notes == null)
            {
                Debug.LogError("JSON 內容不正確或沒有 notes 陣列");
                return;
            }

            Undo.RecordObject(targetChart, "Import Chart From JSON");

            if (targetChart.notes == null)
                targetChart.notes = new List<NoteData>();
            else
                targetChart.notes.Clear();

            targetChart.music = musicData;

            foreach (var jn in jsonChart.notes)
            {
                NoteData nd = new NoteData
                {
                    time = jn.time,
                    lane = jn.lane
                };
                targetChart.notes.Add(nd);
            }

            EditorUtility.SetDirty(targetChart);
            AssetDatabase.SaveAssets();

            Debug.Log($"匯入完成：共 {targetChart.notes.Count} 筆 notes");
        }
        catch (Exception e)
        {
            Debug.LogError("匯入失敗: " + e);
        }
    }
}
#endif
