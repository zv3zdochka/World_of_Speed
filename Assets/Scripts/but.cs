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
    
    
}


