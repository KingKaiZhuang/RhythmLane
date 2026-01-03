using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMusicProgress : MonoBehaviour
{
    
    // 音樂來源
    public AudioSource audioSource;
    // 進度條
    public Slider progressSlider;
    // 淡出效果管理器
    public FadeManager fadeManager;

    void Start() {
        // 獲取 AudioSource 組件
        audioSource = GetComponent<AudioSource>();

        if(audioSource == null) {
            Debug.LogError("找不到 AudioSource");
            return;
        }
        // 設定不循環播放
        audioSource.loop = false;
    }
    
    void Update()
    {
        if(audioSource == null || audioSource.clip == null) return;
        // 目前的時間除上總時間 = 滑桿的值
        progressSlider.value = audioSource.time / audioSource.clip.length;

        // 如果在編輯器模式下按下 T 鍵，跳到音樂結束前 2 秒 (測試用)
        if (Application.isEditor && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log($"[Debug] Skipping to end. Clip Length: {audioSource.clip.length}");
            audioSource.time = audioSource.clip.length - 2f;
        }

        // 當音樂播放結束且遊戲時間大於 1 秒時，進入結算畫面
        if (!audioSource.isPlaying && Time.timeSinceLevelLoad > 1f)
        {
            Debug.Log("[Game Flow] Music finished. Loading Result scene...");
            if (fadeManager != null)
            {
                // 如果有設定淡出管理器，使用淡出並載入
                fadeManager.FadeOutAndLoad("Result");
            }
            else
            {
                // 否則直接載入
                SceneManager.LoadScene("Result");
            }
            // 禁用此腳本，防止重複呼叫
            enabled = false; 
        }
    }
}
