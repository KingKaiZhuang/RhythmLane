using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [System.Serializable]
    public class LaneSetting
    {
        public Transform lane;
        public float spawnInterval = 1f;
        [HideInInspector]
        public float timer = 0f;
    }

    public LaneSetting[] lanes;
    public GameObject arrowPrefab;
    public float spawnOffset = 3f;

    public NoteChart chart;        // 可以留給你在 Inspector 手動指定（測試用）
    public AudioSource music;
    public float approachTime = 2f;

    private int nextNoteIndex = 0;

    void Start()
    {
        // 如果沒在 Inspector 指定 chart，就從 GameData.selectedMusic 拿
        if (chart == null && GameData.selectedMusic != null)
        {
            chart = GameData.selectedMusic.noteChart;
        }

        if (chart == null)
        {
            Debug.LogError("ArrowSpawner: 找不到 NoteChart，請確認 MusicData 有指定 noteChart");
            return;
        }

        if (music == null)
        {
            Debug.LogError("ArrowSpawner: 沒有指定 AudioSource");
            return;
        }

        // 播放這份譜面對應的音樂
        // 優先用 chart.music，沒有的話就用 selectedMusic 的 audioClip
        if (chart.music != null && chart.music.audioClip != null)
        {
            music.clip = chart.music.audioClip;
        }
        else if (GameData.selectedMusic != null && GameData.selectedMusic.audioClip != null)
        {
            music.clip = GameData.selectedMusic.audioClip;
        }

        music.Play();
    }

    void Update()
    {
        if (chart == null || chart.notes == null) return;
        if (nextNoteIndex >= chart.notes.Count) return;

        NoteData note = chart.notes[nextNoteIndex];

        if (music.time >= note.time - approachTime)
        {
            SpawnNoteFromChart(note);
            nextNoteIndex++;
        }
    }

    void SpawnNoteFromChart(NoteData note)
    {
        LaneSetting laneSetting = lanes[note.lane];
        Transform lane = laneSetting.lane;

        Vector2 spawnPos = new Vector2(
            lane.position.x,
            lane.position.y + spawnOffset
        );

        GameObject arrowObj = Instantiate(arrowPrefab, spawnPos, Quaternion.identity);
        Arrow arrow = arrowObj.GetComponent<Arrow>();
        arrow.SetLane(lane);

        // 新增這行：把譜面裡的 lane 設給箭
        arrow.laneIndex = note.lane;
    }
}
