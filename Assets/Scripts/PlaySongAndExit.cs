using UnityEngine;

public class PlaySongAndExit : MonoBehaviour
{
    public AudioClip song; 

    private AudioSource audioSource;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = song;

        
        audioSource.Play();
    }

    public void exit()
    {
        
        if (!audioSource.isPlaying)
        {
            // Exit the game

            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // If running in a built executable
            Application.Quit();
#endif
        }
    }
}