using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource sound1;
    public AudioSource sound2;

    public void CrossfadeSounds()
    {
        StartCoroutine(CrossfadeRoutine());
    }

    private IEnumerator CrossfadeRoutine()
    {
        float fadeDuration = 0.5f; // Длительность затухания/нарастания звуков (в секундах)

        // Затухание первого звука
        float startVolume1 = sound1.volume;
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            sound1.volume = Mathf.Lerp(startVolume1, 0f, timer / fadeDuration);
            yield return null;
        }
        sound1.Stop();

        // Включение и постепенное нарастание второго звука
        sound2.volume = 0f;
        sound2.Play();
        float startVolume2 = sound2.volume;
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            sound2.volume = Mathf.Lerp(startVolume2, 1f, timer / fadeDuration);
            yield return null;
        }
    }
}