using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TextMeshPro money_text;
    public int money = 0;
    void Start()
    {
        money_text = GetComponent<TextMeshPro>();
        Debug.Log(money_text == null);
    }

    
    void Update()
    {
        
        Update_money();

    }
    
    
    void Update_money()
    {
        
        money = PlayerPrefs.GetInt("Money");    
        Debug.Log(money);
        
        money_text.text = "Money: " + money.ToString();
        
    }
    

    void UpdateTimerText()
    {
        int seconds = (int)(timeRemaining % 60);
        int minutes = (int)(timeRemaining / 60) % 60;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


