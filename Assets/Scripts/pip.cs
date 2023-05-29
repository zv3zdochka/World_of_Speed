using UnityEngine;

public class pip : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound();
        }
    }

    private void PlaySound()
    {
        audioSource.PlayOneShot(soundClip);
    }
}