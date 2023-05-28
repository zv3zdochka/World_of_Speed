using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coins: MonoBehaviour
{
    public TMP_Text money_text;
    public int money = 0;
    void Start()
    {
        money_text = GetComponent<TMP_Text>();
    }

    
    void Update()
    {
        
        money = PlayerPrefs.GetInt("Money");
        money_text.text = "Money:" + money.ToString();

    }
    
    
   
}


