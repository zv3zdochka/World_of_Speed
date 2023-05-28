using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartFinishScript : MonoBehaviour
{
    public TimerScript timer;
    public int mon = 0;
    public int stars;
    public AudioSource border;
    public AudioSource portal;
    public AudioSource bo_up;
    public AudioSource Bo_down;
    public AudioSource start;
    public AudioSource coin;
    public AudioSource prf;

    private bool isStartSoundPlaying = false;

    private void Start()
    {
        LoadSounds();
        prf.Play();
    }

    private void LoadSounds()
    {
        border = gameObject.AddComponent<AudioSource>();
        portal = gameObject.AddComponent<AudioSource>();
        bo_up = gameObject.AddComponent<AudioSource>();
        Bo_down = gameObject.AddComponent<AudioSource>();
        start = gameObject.AddComponent<AudioSource>();
        coin = gameObject.AddComponent<AudioSource>();
        prf = gameObject.AddComponent<AudioSource>();

        border.clip = Resources.Load<AudioClip>("border");
        portal.clip = Resources.Load<AudioClip>("level");
        bo_up.clip = Resources.Load<AudioClip>("p_down");
        prf.clip = Resources.Load<AudioClip>("start1");
        Bo_down.clip = Resources.Load<AudioClip>("p_up");
        start.clip = Resources.Load<AudioClip>("start");
        coin.clip = Resources.Load<AudioClip>("coin");
    }

    private void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    static int Return_stars(int sec, string level)
    {
        switch (level)
        {
            case "LEVEL_1":
                if (sec <= 12)
                    return 3;
                else if (sec <= 15)
                    return 2;
                else
                    return 1;

            case "LEVEL_2":
                if (sec <= 20)
                    return 3;
                else if (sec <= 25)
                    return 2;
                else
                    return 1;

            case "LEVEL_3":
                if (sec <= 20)
                    return 3;
                else if (sec <= 25)
                    return 2;
                else
                    return 1;

            case "LEVEL_4":
                if (sec <= 23)
                    return 3;
                else if (sec <= 27)
                    return 2;
                else
                    return 1;

            case "LEVEL_5":
                if (sec <= 40)
                    return 3;
                else if (sec <= 50)
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
        Debug.Log("im in");
        sound.Play();
        yield return new WaitForSeconds(sound.clip.length + 10f);
        Debug.Log(sound.clip.length);
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName == "-1")
        {
            RestartScene();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("start"))
        {
            if (!isStartSoundPlaying)
            {
                Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
                player.speed = 0;
                StartCoroutine(PlaySoundAndLoadScene(start, null));
                timer.StartTimer();
                isStartSoundPlaying = true;
            }
        }
        else if (other.gameObject.CompareTag("portal"))
        {
            StartCoroutine(PlaySoundAndLoadScene(portal, "Menu"));
            timer.StopTimer();
            Destroy(other.gameObject);
            string currentSceneName = SceneManager.GetActiveScene().name;
            float timeInSeconds = timer.GetTime();
            int seconds = Mathf.FloorToInt(timeInSeconds);
            stars = Return_stars(seconds, currentSceneName);
            PlayerPrefs.SetInt(currentSceneName, stars);
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            mon = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", player.coins + mon);
            SceneManager.LoadScene("Menu");
        }
        else if (other.gameObject.CompareTag("Bo_up"))
        {
            StartCoroutine(PlaySoundAndLoadScene(bo_up, null));
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.speed += 7;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Bo_down"))
        {
            StartCoroutine(PlaySoundAndLoadScene(Bo_down, null));
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.speed -= 5;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            StartCoroutine(PlaySoundAndLoadScene(coin, null));
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.coins += 1;
            Destroy(other.gameObject);
        }
        
        else if (other.gameObject.CompareTag("Respawn"))
        {
            
            
            StartCoroutine(PlaySoundAndLoadScene(border, "-1"));
            
            
            
            
            
        }
    }
}
