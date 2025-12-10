using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [System.Serializable]
    public class LaneSetting
    {
        public Transform lane;
        public float spawnInterval = 1f;   // 不再使用，但保留不破壞結構
        [HideInInspector]
        public float timer = 0f;
    }

    public LaneSetting[] lanes;       // Lane1, Lane2, Lane3, Lane4
    public GameObject arrowPrefab;
    public float spawnOffset = 3f;

    // 新增：譜面、音樂、落下時間
    public NoteChart chart;
    public AudioSource music;
    public float approachTime = 2f;

    private int nextNoteIndex = 0;

    void Start()
    {
        if (chart == null)
        {
            Debug.LogError("ArrowSpawner: 沒有指定 NoteChart");
            return;
        }

        if (music == null)
        {
            Debug.LogError("ArrowSpawner: 沒有指定 AudioSource");
            return;
        }

        // 播放音樂
        music.clip = chart.music.audioClip;
        music.Play();
    }

    void Update()
    {
        if (chart == null || chart.notes == null)
            return;

        // 若音符播放完畢
        if (nextNoteIndex >= chart.notes.Count)
            return;

        NoteData note = chart.notes[nextNoteIndex];

        // 當音樂時間 >= (音符時間 - 落下時間) → 生成箭頭
        if (music.time >= note.time - approachTime)
        {
            SpawnNoteFromChart(note);
            nextNoteIndex++;
        }
    }

    void SpawnNoteFromChart(NoteData note)
    {
        // Lane 是 int → 對應到你的 lanes 陣列
        LaneSetting laneSetting = lanes[note.lane];
        Transform lane = laneSetting.lane;

        // 使用你原本的 SpawnArrow 邏輯
        Vector3 spawnPos = new Vector3(
            lane.position.x,
            lane.position.y + spawnOffset,
            lane.position.z
        );

        GameObject arrowObj = Instantiate(arrowPrefab, spawnPos, Quaternion.identity);
        Arrow arrow = arrowObj.GetComponent<Arrow>();
        arrow.SetLane(lane);
    }
}
