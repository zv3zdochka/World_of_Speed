using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class but : MonoBehaviour
{
    

    
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
    
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
    
    public void CheckAndLoadLevel1()
    {
        SceneManager.LoadScene("LEVEL_1");
    }

    public void CheckAndLoadLevel2()
    {
        if (PlayerPrefs.GetInt("LEVEL_1", 0) >= 1)
        {
            SceneManager.LoadScene("LEVEL_2");
        }
    }

    public void CheckAndLoadLevel3()
    {
        if (PlayerPrefs.GetInt("LEVEL_2", 0) >= 1)
        {
            SceneManager.LoadScene("LEVEL_3");
        }
    }

    public void CheckAndLoadLevel4()
    {
        if (PlayerPrefs.GetInt("LEVEL_3", 0) >= 1)
        {
            SceneManager.LoadScene("LEVEL_4");
        }
    }

    public void CheckAndLoadLevel5()
    {
        if (PlayerPrefs.GetInt("LEVEL_4", 0) >= 1)
        {
            SceneManager.LoadScene("LEVEL_5");
        }
    }
    public void reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
}


