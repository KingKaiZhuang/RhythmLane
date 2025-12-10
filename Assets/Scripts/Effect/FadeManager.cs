using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1f;

    void Start()
    {
        fadeGroup.alpha = 0;  
    }

    public void FadeOutAndLoad(string sceneName)
    {
        StartCoroutine(FadeOutRoutine(sceneName));
    }

    IEnumerator FadeOutRoutine(string sceneName)
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}

