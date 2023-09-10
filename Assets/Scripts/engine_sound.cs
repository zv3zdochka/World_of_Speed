using UnityEngine;

public class engine_sound : MonoBehaviour
{
    public AudioSource sound1;
    public AudioSource sound2;
    public float volumeChangeDuration = 2.5f;

    private bool isPlayingSound1;
    private bool isPlayingSound2;
    private bool isPlayingSound3;
    private bool isWaiting;
    private float sound1TargetVolume;
    private float sound2TargetVolume;
    private float volumeChangeStartTime;

    private void Start()
    {
        sound1 = gameObject.AddComponent<AudioSource>();
        sound2 = gameObject.AddComponent<AudioSource>();

        sound1.clip = Resources.Load<AudioClip>("b_s");
        sound2.clip = Resources.Load<AudioClip>("a_s");

        sound1.loop = true;
        sound2.loop = true;

        isWaiting = true;
        isPlayingSound1 = false;
        isPlayingSound2 = false;
        isPlayingSound3 = false;

        StartCoroutine(PlayDelayedSound1());
    }

    private System.Collections.IEnumerator PlayDelayedSound1()
    {
        yield return new WaitForSeconds(1.3f); 

        isWaiting = false;
        sound1.Play();
        isPlayingSound1 = true;
    }

    private void Update()
    {

        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isSPressed = Input.GetKey(KeyCode.S);
        bool isSpacePressed = Input.GetKey(KeyCode.Space);


        if (!isWPressed && !isSPressed && !isSpacePressed && !isPlayingSound2 && !isPlayingSound3 && !isWaiting)
        {
            if (!isPlayingSound1)
            {
                sound1.Play();
                isPlayingSound1 = true;
                sound1TargetVolume = 1.0f;
                volumeChangeStartTime = Time.time;
            }
        }

        else if ((isWPressed || isSPressed) && !isPlayingSound3)
        {
            if (!isPlayingSound2)
            {
                sound1.Stop();
                sound2.Play();
                isPlayingSound2 = true;
                sound2TargetVolume = 1.0f;
                volumeChangeStartTime = Time.time;
            }
        }
        
        else if (isSpacePressed)
        {
            sound1.Stop();
            sound2.Stop();
            isPlayingSound3 = true;
        }
        
        else
        {
            sound1.Stop();
            sound2.Stop();
            isPlayingSound1 = false;
            isPlayingSound2 = false;
            isPlayingSound3 = false;
            sound1TargetVolume = 0.0f;
            sound2TargetVolume = 0.0f;
            volumeChangeStartTime = Time.time;
        }

        
        if (isPlayingSound1)
        {
            float elapsed = Time.time - volumeChangeStartTime;
            float t = Mathf.Clamp01(elapsed / volumeChangeDuration);
            sound1.volume = Mathf.Lerp(1.0f, sound1TargetVolume, t);
        }

        
        if (isPlayingSound2)
        {
            float elapsed = Time.time - volumeChangeStartTime;
            float t = Mathf.Clamp01(elapsed / volumeChangeDuration);
            sound2.volume = Mathf.Lerp(0.0f, 1.0f, t);
        }
    }
}
