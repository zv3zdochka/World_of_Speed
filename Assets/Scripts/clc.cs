using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clc : MonoBehaviour
{
    public int mon;
    public void back()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void Red()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 1)
        {
            PlayerPrefs.SetInt("CarTextureIndex", 0);
            PlayerPrefs.SetInt("Money", mon -= 1);
            PlayerPrefs.Save();
        }
    }
    
    public void Grey()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 5)
        {
            PlayerPrefs.SetInt("CarTextureIndex", 1);
            PlayerPrefs.SetInt("Money", mon -= 5);
            PlayerPrefs.Save();
        }
        
        
    }
    
    public void Purple()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 10)
        {
            PlayerPrefs.SetInt("CarTextureIndex", 2);
            PlayerPrefs.SetInt("Money", mon -= 10);
            PlayerPrefs.Save();
        }
    }
    
    public void Blue()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 20)
        {
            PlayerPrefs.SetInt("CarTextureIndex", 3);
            PlayerPrefs.SetInt("Money", mon -= 20);
            PlayerPrefs.Save();
        }
    }
    
    public void Yellow()
    {
        mon = PlayerPrefs.GetInt("Money");
        if (mon >= 50)
        {
            PlayerPrefs.SetInt("CarTextureIndex", 4);
            PlayerPrefs.SetInt("Money", mon -= 50);
            PlayerPrefs.Save();
        }
    }
}


