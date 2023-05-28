using UnityEngine;

public class BGMController : MonoBehaviour
{
    static BGMController s_instance = null;

    public static BGMController Instance
    {
        get
        {
            if(s_instance == null)
            {
                s_instance = FindObjectOfType<BGMController>();

                if(s_instance == null)
                {
                    s_instance = new GameObject("[BGMController]").AddComponent<BGMController>();
                }

                DontDestroyOnLoad(s_instance);
            }

            return s_instance;
        }
    }

    private void Awake()
    {
        if(s_instance != null && s_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        m_introBgmAudioSource = gameObject.AddComponent<AudioSource>();
        m_bgmAudioSource = gameObject.AddComponent<AudioSource>();
    }

    float m_bgmVolume = 1;
    public float BGMVolume
    {
        get { return m_bgmVolume; }
        set
        {
            value = Mathf.Clamp01(value);
            m_bgmVolume = value;
            m_introBgmAudioSource.volume = value;
            m_bgmAudioSource.volume = value;
        }
    }

    AudioSource m_introBgmAudioSource;
    AudioSource m_bgmAudioSource;

    public void PlayBGM(AudioClip p_bgmClip, bool p_loop = true, float volume = 1)
    {
        m_bgmAudioSource.Stop();
        m_bgmAudioSource.clip = p_bgmClip;
        m_bgmAudioSource.loop = p_loop;
        m_bgmAudioSource.volume = BGMVolume * volume;
        m_bgmAudioSource.Play();
    }

    public void PlayBGMWithIntro(AudioClip p_introClip, AudioClip p_bgmClip, bool p_loopBGM = true, float volume = 1)
    {
        m_introBgmAudioSource.Stop();
        m_introBgmAudioSource.clip = p_introClip;
        m_introBgmAudioSource.loop = false;
        m_introBgmAudioSource.volume = BGMVolume * volume;
        m_introBgmAudioSource.Play();

        m_bgmAudioSource.Stop();
        m_bgmAudioSource.clip = p_bgmClip;
        m_bgmAudioSource.loop = p_loopBGM;
        m_bgmAudioSource.volume = BGMVolume * volume;
        m_bgmAudioSource.PlayDelayed(p_introClip.length);
    }
}
