using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChartRecorder : MonoBehaviour
{
    public AudioSource music;
    public NoteChart targetChart;
    public bool autoClearOnStart = true;


    public KeyCode[] keysPerLane = {
        KeyCode.UpArrow,
        KeyCode.LeftArrow,
        KeyCode.DownArrow,
        KeyCode.RightArrow
    };

    void Start()
    {
        if (targetChart.notes == null)
            targetChart.notes = new List<NoteData>();

        music.Play();
    }

    void Update()
    {
        for (int lane = 0; lane < keysPerLane.Length; lane++)
        {
            if (Input.GetKeyDown(keysPerLane[lane]))
            {
                AddNote(lane);
            }
        }
    }

    void AddNote(int lane)
    {
        float t = music.time;

        NoteData note = new NoteData { time = t, lane = lane };
        targetChart.notes.Add(note);

        Debug.Log($"Note added: time={t}, lane={lane}");

#if UNITY_EDITOR
        EditorUtility.SetDirty(targetChart);
        AssetDatabase.SaveAssets();
#endif
    }
}
