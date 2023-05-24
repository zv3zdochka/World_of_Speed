using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coins: MonoBehaviour
{
    public Text money_text;
    public int money = 0;
    void Start()
    {
        money_text = GetComponent<Text>();
        Debug.Log(money_text == null);
    }

    
    void Update()
    {
        
        money = PlayerPrefs.GetInt("Money");    
        Debug.Log(money);
        money_text.text = "Money: " + money.ToString();

    }
    
    
   
}


