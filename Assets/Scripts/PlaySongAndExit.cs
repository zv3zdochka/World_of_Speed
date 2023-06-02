using UnityEngine;

public class PlaySongAndExit : MonoBehaviour
{
    public AudioClip song; // Audio clip with the song

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = song;

        // Play the song
        audioSource.Play();
    }

    public void exit()
    {
        // Check if the song playback is complete
        if (!audioSource.isPlaying)
        {
            // Exit the game

            // If running in the Unity editor
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // If running in a built executable
            Application.Quit();
#endif
        }
    }
}