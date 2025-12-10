using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteData
{
    public float time;  // 音樂中第幾秒
    public int lane;    // 第幾軌（0,1,2,3）
}

[CreateAssetMenu(fileName = "NoteChart", menuName = "Rhythm/NoteChart")]
public class NoteChart : ScriptableObject
{
    public MusicData music;        // 使用哪一首歌
    public List<NoteData> notes;   // 譜面資料
}
