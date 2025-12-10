using System.Collections;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource.loop = true;
        audioSource.Play();
    }

    public IEnumerator FadeOut(float duration)
    {
        float startVolume = audioSource.volume;
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
