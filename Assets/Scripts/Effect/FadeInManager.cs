using System.Collections;
using UnityEngine;

public class FadeInManager : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float t = 0;
        fadeGroup.alpha = 1;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = 1 - (t / fadeDuration);
            yield return null;
        }

        fadeGroup.alpha = 0;
    }
}
