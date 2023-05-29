using UnityEngine;

public class PlaySongAndExit : MonoBehaviour
{
    public AudioClip song; // Аудиоклип с песней

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = song;
        audioSource.Play();
    }

    public void exit()
    {
        // Проверяем, завершено ли воспроизведение песни
        if (!audioSource.isPlaying)
        {
            // Выходим из игры
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}