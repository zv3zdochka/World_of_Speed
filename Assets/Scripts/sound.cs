using UnityEngine;

public class sound : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the same GameObject
        audioSource.loop = true; // Set the audio to loop
        audioSource.Play(); // Play the audio
    }

    void Update()
    {
        // Check if the game object is active in the hierarchy
        if (!gameObject.activeInHierarchy)
        {
            audioSource.Stop(); // Stop the audio playback if the game object is not active
        }
    }
}