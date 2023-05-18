using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 0;
    private bool isTimerRunning = false;
    private TextMeshPro timerText;

    void Start()
    {
        timerText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeRemaining += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int seconds = (int)(timeRemaining % 60);
        int minutes = (int)(timeRemaining / 60) % 60;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        timeRemaining = 0;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("start"))
        {
            StartTimer();
        }
        else if (other.gameObject.CompareTag("portal"))
        {
            StopTimer();
            Debug.Log("Hello, world!");    
        }
    }   
}
