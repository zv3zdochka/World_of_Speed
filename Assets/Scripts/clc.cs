using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class clc : MonoBehaviour
{
    public int mon;
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
        sound2.clip = Resources.Load<AudioClip>("coin_spell");
        sound3.clip = Resources.Load<AudioClip>("low_m");
        backgroundMusic.clip = Resources.Load<AudioClip>("Shop");

        backgroundMusic.loop = true;

        backgroundMusic.Play();
    }

    public void back()
    {
        StartCoroutine(PlaySoundAndLoadScene(sound1, "Menu"));
    }

    private IEnumerator PlaySoundAndLoadScene(AudioSource sound, string sceneName)
    {
        sound.Play();
        yield return new WaitForSeconds(sound.clip.length);
        SceneManager.LoadScene(sceneName);
    }


    public void Red()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 1)
        {
            sound2.Play();
            PlayerPrefs.SetInt("CarTextureIndex", 0);
            PlayerPrefs.SetInt("Money", mon -= 1);
            PlayerPrefs.Save();
        }
        else
        {
            sound3.Play();
        }
    }

    public void Grey()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 5)
        {
            sound2.Play();
            PlayerPrefs.SetInt("CarTextureIndex", 1);
            PlayerPrefs.SetInt("Money", mon -= 5);
            PlayerPrefs.Save();
        }
        else
        {
            sound3.Play();
        }
    }

    public void Purple()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 10)
        {
            sound2.Play();
            PlayerPrefs.SetInt("CarTextureIndex", 2);
            PlayerPrefs.SetInt("Money", mon -= 10);
            PlayerPrefs.Save();
        }
        else
        {
            sound3.Play();
        }
    }

    public void Blue()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 20)
        {
            sound2.Play();
            PlayerPrefs.SetInt("CarTextureIndex", 3);
            PlayerPrefs.SetInt("Money", mon -= 20);
            PlayerPrefs.Save();
        }
        else
        {
            sound3.Play();
        }
    }

    public void Yellow()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 50)
        {
            sound2.Play();
            PlayerPrefs.SetInt("CarTextureIndex", 4);
            PlayerPrefs.SetInt("Money", mon -= 50);
            PlayerPrefs.Save();
        }
        else
        {
            sound3.Play();
        }
    }
}
