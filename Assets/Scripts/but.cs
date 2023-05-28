using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class but : MonoBehaviour
{
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource backgroundMusic;

    void Start()
    {
        sound1 = gameObject.AddComponent<AudioSource>();
        sound2 = gameObject.AddComponent<AudioSource>();
        sound3 = gameObject.AddComponent<AudioSource>();
        backgroundMusic = gameObject.AddComponent<AudioSource>();

        sound1.clip = Resources.Load<AudioClip>("back");
        sound2.clip = Resources.Load<AudioClip>("close");
        sound3.clip = Resources.Load<AudioClip>("low_m");
        backgroundMusic.clip = Resources.Load<AudioClip>("Menu");

        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }

    public void Shop()
    {
        StartCoroutine(PlaySoundAndLoadScene(sound1, "Shop"));
    }

    public void Exit()
    {
        StartCoroutine(PlaySoundAndQuitGame(sound2));
    }

    private IEnumerator PlaySoundAndQuitGame(AudioSource audioSource)
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void CheckAndLoadLevel1()
    {
        StartCoroutine(PlaySoundAndLoadScene(sound1, "LEVEL_1"));
    }

    public void CheckAndLoadLevel2()
    {
        if (PlayerPrefs.GetInt("LEVEL_1", 0) >= 1)
        {
            StartCoroutine(PlaySoundAndLoadScene(sound1, "LEVEL_2"));
        }
        else
        {
            sound3.Play();
        }
    }

    public void CheckAndLoadLevel3()
    {
        if (PlayerPrefs.GetInt("LEVEL_2", 0) >= 1)
        {
            StartCoroutine(PlaySoundAndLoadScene(sound1, "LEVEL_3"));
        }
        else
        {
            sound3.Play();
        }
    }

    public void CheckAndLoadLevel4()
    {
        if (PlayerPrefs.GetInt("LEVEL_3", 0) >= 1)
        {
            StartCoroutine(PlaySoundAndLoadScene(sound1, "LEVEL_4"));
        }
        else
        {
            sound3.Play();
        }
    }

    public void CheckAndLoadLevel5()
    {
        if (PlayerPrefs.GetInt("LEVEL_4", 0) >= 1)
        {
            StartCoroutine(PlaySoundAndLoadScene(sound1, "LEVEL_5"));
        }
        else
        {
            sound3.Play();
        }
    }

    public void reset()
    {
        StartCoroutine(PlaySoundAndReset(sound1));
    }

    public void back()
    {
        StartCoroutine(PlaySoundAndLoadScene(sound2, "Menu"));
    }

    private IEnumerator PlaySoundAndLoadScene(AudioSource audioSource, string sceneName)
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator PlaySoundAndReset(AudioSource audioSource)
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
}
