using UnityEngine.SceneManagement;
using UnityEngine;

public class StartFinishScript : MonoBehaviour
{
    public TimerScript timer;
    public int mon = 0;

    
    
    private void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
            PlayerPrefs.SetInt(currentSceneName, seconds);
            
            
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