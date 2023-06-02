using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarDrawer : MonoBehaviour
{
    public GameObject starPrefab; // Prefab for the star object
    public Transform canvasTransform; // Reference to the canvas transform
    private AudioSource audioSource; // Reference to the AudioSource component

    int GetStarsCount(string levelName)
    {
        return PlayerPrefs.GetInt(levelName, 0); // Get the number of stars collected for the specified level name from PlayerPrefs
    }

    void DrawStars(int starCount, Vector2[] starPositions)
    {
        for (int i = 0; i < starCount; i++)
        {
            // Instantiate a star object using the starPrefab and attach it to the canvasTransform
            GameObject star = Instantiate(starPrefab, Vector3.zero, Quaternion.identity, canvasTransform);
            Image starImage = star.GetComponent<Image>(); // Get the Image component of the star object
            RectTransform starRectTransform = star.GetComponent<RectTransform>(); // Get the RectTransform component of the star object

            starRectTransform.anchoredPosition = starPositions[i]; // Set the anchored position of the star object based on the starPositions array
        }
    }

    void LEVEL_1()
    {
        string levelName = "LEVEL_1"; // Name of level 1
        int stars = GetStarsCount(levelName); // Get the number of stars collected for level 1

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(-275f, 35f),
            new Vector2(-223f, 35f),
            new Vector2(-175f, 35f)
        };

        DrawStars(stars, starPositions); // Draw the stars for level 1 based on the number of stars collected
    }

    void LEVEL_2()
    {
        string levelName = "LEVEL_2"; // Name of level 2
        int stars = GetStarsCount(levelName); // Get the number of stars collected for level 2

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(-46f, 35f),
            new Vector2(4f, 35f),
            new Vector2(54f, 35f)
        };

        DrawStars(stars, starPositions); // Draw the stars for level 2 based on the number of stars collected
    }

    void LEVEL_3()
    {
        string levelName = "LEVEL_3"; // Name of level 3
        int stars = GetStarsCount(levelName); // Get the number of stars collected for level 3

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(185f, 35f),
            new Vector2(235f, 35f),
            new Vector2(285f, 35f)
        };

        DrawStars(stars, starPositions); // Draw the stars for level 3 based on the number of stars collected
    }

    void LEVEL_4()
    {
        string levelName = "LEVEL_4"; // Name of level 4
        int stars = GetStarsCount(levelName); // Get the number of stars collected for level 4

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(-165f, -135f),
            new Vector2(-115f, -135f),
            new Vector2(-64f, -135f)
        };

        DrawStars(stars, starPositions); // Draw the stars for level 4 based on the number of stars collected
    }

    void LEVEL_5()
    {
        string levelName = "LEVEL_5"; // Name of level 5
        int stars = GetStarsCount(levelName); // Get the number of stars collected for level 5

        Vector2[] starPositions = new Vector2[]
        {
            new Vector2(72f, -135f),
            new Vector2(123f, -135f),
            new Vector2(173f, -135f)
        };

        DrawStars(stars, starPositions); // Draw the stars for level 5 based on the number of stars collected
    }

    void CheckStarsCount()
    {
        int totalStars = 0;
        
        totalStars += GetStarsCount("LEVEL_1"); // Get the total number of stars collected from level 1
        totalStars += GetStarsCount("LEVEL_2"); // Get the total number of stars collected from level 2
        totalStars += GetStarsCount("LEVEL_3"); // Get the total number of stars collected from level 3
        totalStars += GetStarsCount("LEVEL_4"); // Get the total number of stars collected from level 4
        totalStars += GetStarsCount("LEVEL_5"); // Get the total number of stars collected from level 5

        if (totalStars == 15) 
        {
            SceneManager.LoadScene("Ens"); // Load the "Ens" scene if the total number of stars collected is 15
        }
    }

    void Start()
    {
        LEVEL_1(); // Draw stars for level 1
        LEVEL_2(); // Draw stars for level 2
        LEVEL_3(); // Draw stars for level 3
        LEVEL_4(); // Draw stars for level 4
        LEVEL_5(); // Draw stars for level 5
        CheckStarsCount(); // Check if the total number of stars collected is 15
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the same game object
        audioSource.loop = true; // Set the audio source to loop
        audioSource.Play(); // Play the audio
    }
    
    void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            audioSource.Stop(); // Stop the audio if the game object is not active in the hierarchy
        }
    }
}
