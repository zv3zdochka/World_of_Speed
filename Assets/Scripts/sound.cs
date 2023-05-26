using UnityEngine;

public class sound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; 
        audioSource.Play(); 
    }

    void Update()
    {
        
        if (!gameObject.activeInHierarchy)
        {
            audioSource.Stop(); 
        }
    }
}