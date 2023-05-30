using UnityEngine;
using UnityEngine.UI;
using Unity.Audio;
using UnityEngine.SceneManagement;

public class StarDrawer : MonoBehaviour
{
    public GameObject starPrefab;
    public Transform canvasTransform;
    private AudioSource audioSource;
    int GetStarsCount(string levelName)
    {
        return PlayerPrefs.GetInt(levelName, 0);
    }

    void DrawStars(int starCount, Vector2[] starPositions)
    {
        

        for (int i = 0; i < starCount; i++)
        {
            GameObject star = Instantiate(starPrefab, Vector3.zero, Quaternion.identity, canvasTransform);
            Image starImage = star.GetComponent<Image>();
            RectTransform starRectTransform = star.GetComponent<RectTransform>();

            starRectTransform.anchoredPosition = starPositions[i];
        }
    }

    void LEVEL_1()
    {
        string levelName = "LEVEL_1";
        int stars = GetStarsCount(levelName);

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(-275f, 35f),
            new Vector2(-223f, 35f),
            new Vector2(-175f, 35f)
        };

        DrawStars(stars, starPositions);
    }

    void LEVEL_2()
    {
        string levelName = "LEVEL_2";
        int stars = GetStarsCount(levelName);

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(-46f, 35f),
            new Vector2(4f, 35f),
            new Vector2(54f, 35f)
        };

        DrawStars(stars, starPositions);
    }

    void LEVEL_3()
    {
        string levelName = "LEVEL_3";
        int stars = GetStarsCount(levelName);

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(185f, 35f),
            new Vector2(235f, 35f),
            new Vector2(285f, 35f)
        };

        DrawStars(stars, starPositions);
    }
    
    void LEVEL_4()
    {
        string levelName = "LEVEL_4";
        int stars = GetStarsCount(levelName);

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(-165f, -135f),
            new Vector2(-115f, -135f),
            new Vector2(-64f, -135f)
        };

        DrawStars(stars, starPositions);
    }
    
    void LEVEL_5()
    {
        string levelName = "LEVEL_5";
        int stars = GetStarsCount(levelName);

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(72f, -135f),
            new Vector2(123f, -135f),
            new Vector2(173f, -135f)
        };

        DrawStars(stars, starPositions);
    }

    void CheckStarsCount()
    {
        int totalStars = 0;
        
        totalStars += GetStarsCount("LEVEL_1");
        totalStars += GetStarsCount("LEVEL_2");
        totalStars += GetStarsCount("LEVEL_3");
        totalStars += GetStarsCount("LEVEL_4");
        totalStars += GetStarsCount("LEVEL_5");

        if (totalStars == 15) 
        {
            SceneManager.LoadScene("Ens");
        }
    }

    void Start()
    {
        LEVEL_1();
        LEVEL_2();
        LEVEL_3();
        LEVEL_4();
        LEVEL_5();
        CheckStarsCount();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; 
        audioSource.Play(); 
    }
    
    void Update()
    {
        
        if (!gameObject.activeInHierarchy)
        {
            audioSource.Stop(); 
        }
    }
}
