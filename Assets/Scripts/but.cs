using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class but : MonoBehaviour
{
    
    public int click = 0;
    private void Start()
    {
        click += 1;
    }
    
    public void But_click()
    {
        Start();
        Debug.Log(click);
    }
    
    
}


