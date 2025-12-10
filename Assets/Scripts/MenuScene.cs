using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform buttonTransform;
    public float animDuration = 0.2f;
    public FadeManager fadeManager;       // 畫面淡出
    public PlayBGM bgmPlayer;             // 音樂控制器

    public void StartGame()
    {
        StartCoroutine(PlayAnimationAndLoad());
    }

    IEnumerator PlayAnimationAndLoad()
    {
        Vector2 startScale = buttonTransform.localScale;
        Vector2 targetScale = startScale * 0.9f;

        float t = 0;
        while (t < animDuration)
        {
            t += Time.deltaTime;
            float progress = t / animDuration;
            buttonTransform.localScale = Vector2.Lerp(startScale, targetScale, progress);
            yield return null;
        }
        
        StartCoroutine(bgmPlayer.FadeOut(1f)); // 1秒淡出

        string targetScene = "SongSelect";
        // 這裡改成呼叫淡出，而不是直接 LoadScene
        fadeManager.FadeOutAndLoad(targetScene);
    }
}
