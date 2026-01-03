using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "Rhythm/MusicData")]
public class MusicData : ScriptableObject
{
    // 音樂名稱
    public string musicName;
    // 作者
    public string author;
    // 音訊片段
    public AudioClip audioClip;
    // 封面圖片
    public Sprite coverImage;
    // 音訊長度
    public float length;
    // 這首歌對應的譜面
    public NoteChart noteChart;
}
