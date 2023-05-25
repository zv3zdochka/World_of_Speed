using UnityEngine.SceneManagement;
using UnityEngine;

public class StartFinishScript : MonoBehaviour
{
    public TimerScript timer;
    public int mon = 0;
    public int stars; 
    
    
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
    
    
    
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("start"))
        {
            timer.StartTimer();
        }
        else if (other.gameObject.CompareTag("portal"))
        {
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
        
        
        if (other.gameObject.CompareTag("Bo_up"))
        {
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.speed += 7;
            Destroy(other.gameObject);    
        }
        else if (other.gameObject.CompareTag("Bo_down"))
        {
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.speed -= 5;
            Destroy(other.gameObject);    
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            Move player = GameObject.FindWithTag("Player").GetComponent<Move>();
            player.coins += 1;
            Destroy(other.gameObject);
        }
        
        
        if (other.gameObject.CompareTag("Respawn"))
        {
            RestartScene();
        }
        
        
    
    }   
}