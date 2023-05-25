using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_lev_ti : MonoBehaviour
{
    public GameObject levelIconPrefab; 
    public Transform iconsParent; 

    private void Start()
    {
        
        for (int level = 1; level <= 5; level++)
        {
            
            //GameObject levelIcon = Instantiate(levelIconPrefab, iconsParent);

            
            float stars = PlayerPrefs.GetFloat("LEVEL_" + level, 0f);

            
            //int stars = Mathf.FloorToInt(time / 10f);

            
            //SetStarsCount(levelIcon, stars);
        }
    }

    private void SetStarsCount(GameObject levelIcon, int count)
    {
        
        Image starsImage = levelIcon.GetComponentInChildren<Image>();

            
        starsImage.fillAmount = count / 10f;
    }
}
