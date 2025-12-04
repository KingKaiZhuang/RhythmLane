using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMusicProgress : MonoBehaviour
{
    
    public AudioSource audioSource;
    public Slider progressSlider;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        if(audioSource == null) {
            Debug.LogError("找不到 AudioSource");
            return;
        }
    }
    
    void Update()
    {
        if(audioSource == null || audioSource.clip == null) return;
        // 目前的時間除上總時間 = 滑桿的值
        progressSlider.value = audioSource.time / audioSource.clip.length;
    }
}
