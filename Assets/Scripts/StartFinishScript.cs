using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartFinishScript : MonoBehaviour
{
    public TimerScript timer; // Reference to the TimerScript component
    public int mon = 0; // Money counter
    public int stars; // Number of stars collected
    public AudioSource border; // Audio source for border sound
    public AudioSource portal; // Audio source for portal sound
    public AudioSource bo_up; // Audio source for boost up sound
    public AudioSource Bo_down; // Audio source for boost down sound
    public AudioSource start; // Audio source for start sound
    public AudioSource coin; // Audio source for coin sound
    public AudioSource prf; // Audio source for prefab sound

    private bool isStartSoundPlaying = false; // Flag to prevent multiple start sounds from playing

    private void Start()
    {
        LoadSounds(); // Load audio sources and assign audio clips
        prf.Play(); // Play the prefab sound
    }

    private void LoadSounds()
    {
        // Add AudioSources and load audio clips from Resources folder
        border = gameObject.AddComponent<AudioSource>();
        portal = gameObject.AddComponent<AudioSource>();
        bo_up = gameObject.AddComponent<AudioSource>();
        Bo_down = gameObject.AddComponent<AudioSource>();
        start = gameObject.AddComponent<AudioSource>();
        coin = gameObject.AddComponent<AudioSource>();
        prf = gameObject.AddComponent<AudioSource>();

        border.clip = Resources.Load<AudioClip>("border");
        portal.clip = Resources.Load<AudioClip>("level");
        Bo_down.clip = Resources.Load<AudioClip>("p_down");
        prf.clip = Resources.Load<AudioClip>("start1");
        bo_up.clip = Resources.Load<AudioClip>("p_up");
        start.clip = Resources.Load<AudioClip>("start");
        coin.clip = Resources.Load<AudioClip>("coin");
    }

    private void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); // Reload the current scene
    }

    static int Return_stars(int sec, string level)
    {
        // Determine the number of stars based on the completion time and level
        switch (level)
        {
            case "LEVEL_1":
                if (sec <= 16)
                    return 3;
                else if (sec <= 19)
                    return 2;
                else
                    return 1;

            case "LEVEL_2":
                if (sec <= 24)
                    return 3;
                else if (sec <= 29)
                    return 2;
                else
                    return 1;

            case "LEVEL_3":
                if (sec <= 24)
                    return 3;
                else if (sec <= 29)
                    return 2;
                else
                    return 1;

            case "LEVEL_4":
                if (sec <= 27)
                    return 3;
                else if (sec <= 31)
                    return 2;
                else
                    return 1;

            case "LEVEL_5":
                if (sec <= 44)
                    return 3;
                else if (sec <= 54)
                    return 2;
                else
                    return 1;

            default:
                Debug.Log("Уровень не распознан.");
                return -1;
        }
    }

    private IEnumerator PlaySoundAndLoadScene(AudioSource sound, string sceneName)
    {
        sound.Play(); // Play the specified sound

        // Wait for the sound to finish playing before loading the scene or restarting the scene
        if (sceneName == "-1")
        {
            yield return new WaitForSeconds(sound.clip.length - 0.7f);
        }
        else if (sceneName == "-2")
        {
            yield return new WaitForSeconds(sound.clip.length - 1.2f);
        }
        else
        {
            yield return new WaitForSeconds(sound.clip.length);
        }

        // Load the scene or restart the scene based on the specified scene name
        if (sceneName == "-1")
        {
            RestartScene();
        }
        else if (sceneName == "-2")
        {
            SceneManager.LoadScene("Menu");
        }
        else if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("start"))
        {
            if (!isStartSoundPlaying)
            {
                Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
                player.speed = 0; // Stop the player's movement
                StartCoroutine(PlaySoundAndLoadScene(start, null)); // Play the start sound and start the timer
                player.speed = 0; // Stop the player's movement
                timer.StartTimer(); // Start the timer
                player.speed = 0; // Stop the player's movement
                isStartSoundPlaying = true; // Set the flag to true to prevent multiple start sounds from playing
                player.speed = 0; // Stop the player's movement
            }
        }
        else if (other.gameObject.CompareTag("portal"))
        {
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.speed = 0; // Stop the player's movement
            StartCoroutine(PlaySoundAndLoadScene(portal, "-2")); // Play the portal sound and load the Menu scene
            timer.StopTimer(); // Stop the timer
            Destroy(other.gameObject); // Destroy the portal object
            string currentSceneName = SceneManager.GetActiveScene().name; // Get the current scene name
            float timeInSeconds = timer.GetTime(); // Get the time in seconds from the timer
            int seconds = Mathf.FloorToInt(timeInSeconds); // Convert the time to integer seconds
            stars = Return_stars(seconds, currentSceneName); // Determine the number of stars based on the time and level
            PlayerPrefs.SetInt(currentSceneName, stars); // Save the number of stars for the current level
            mon = PlayerPrefs.GetInt("Money"); // Get the current money count
            PlayerPrefs.SetInt("Money", player.coins + mon); // Update the money count with the collected coins
        }
        else if (other.gameObject.CompareTag("Bo_up"))
        {
            bo_up.Play(); // Play the boost up sound
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.speed += 7; // Increase the player's speed
            Destroy(other.gameObject); // Destroy the boost up object
        }
        else if (other.gameObject.CompareTag("Bo_down"))
        {
            Bo_down.Play(); // Play the boost down sound
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.speed -= 5; // Decrease the player's speed
            Destroy(other.gameObject); // Destroy the boost down object
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            coin.Play(); // Play the coin sound
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.coins += 1; // Increase the collected coin count
            Destroy(other.gameObject); // Destroy the coin object
        }
        else if (other.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(PlaySoundAndLoadScene(border, "-1")); // Play the border sound and restart the scene
        }
    }
}
