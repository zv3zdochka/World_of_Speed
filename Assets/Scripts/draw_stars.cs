using UnityEngine;
using UnityEngine.UI;

public class StarDrawer : MonoBehaviour
{
    public GameObject starPrefab; // Префаб звездочки
    public float starSpacing = 10f; // Расстояние между звездочками

    
    int GetStarsCount(string levelName)
    {
        return PlayerPrefs.GetInt(levelName, 0);
    }

    // Функция для рисования звездочек на Canvas
    void DrawStars(int starCount)
    {
        Debug.Log(starCount);
        Canvas canvas = GetComponent<Canvas>();

        // Область размешения 
        float totalWidth = (starCount - 1) * starSpacing;
        
        for (int i = 0; i < starCount; i++)
        {
            
            GameObject star = Instantiate(starPrefab, Vector3.zero, Quaternion.identity, canvas.transform);

            
            Image starImage = star.GetComponent<Image>();
            RectTransform starRectTransform = star.GetComponent<RectTransform>();

            
            float xPos = (i * starSpacing) - (totalWidth / 2f);
            starRectTransform.anchoredPosition = new Vector2(xPos, 0f);
        }
    }

    
    void LEVEL_1()
    {
        string levelName = "LEVEL_1";
        int stars = GetStarsCount(levelName);
        DrawStars(stars);
    }

    
    void LEVEL_2()
    {
        string levelName = "LEVEL_2";
        int stars = GetStarsCount(levelName);
        DrawStars(stars);
    }

    
    void LEVEL_3()
    {
        string levelName = "LEVEL_3";
        int stars = GetStarsCount(levelName);
        DrawStars(stars);
    }

    
    void LEVEL_4()
    {
        string levelName = "LEVEL_4";
        int stars = GetStarsCount(levelName);
        DrawStars(stars);
    }

    
    void LEVEL_5()
    {
        string levelName = "LEVEL_5";
        int stars = GetStarsCount(levelName);
        DrawStars(stars);
    }

    
    void Start()
    {
        
        LEVEL_1();
        LEVEL_2();
        LEVEL_3();
        LEVEL_4();
        LEVEL_5();
    }
}
