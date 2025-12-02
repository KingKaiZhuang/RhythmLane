using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "Rhythm/MusicData")]
public class MusicData : ScriptableObject
{
    public string musicName;
    public string author;
    public AudioClip audioClip;
    public Sprite coverImage;
    public int bpm;
    public float length;
}
