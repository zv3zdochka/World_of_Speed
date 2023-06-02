using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 0;
    private bool isTimerRunning = false;
    private TextMeshPro timerText;

    void Start()
    {
        timerText = GetComponent<TextMeshPro>(); // Get the TextMeshPro component attached to the same game object
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeRemaining += Time.deltaTime; // Update the time remaining with the elapsed time
            UpdateTimerText(); // Update the timer text
        }
    }

    void UpdateTimerText()
    {
        int seconds = (int)(timeRemaining % 60); // Calculate the remaining seconds
        int minutes = (int)(timeRemaining / 60) % 60; // Calculate the remaining minutes
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format the timer text as "MM:SS"
    }

    public void StartTimer()
    {
        timeRemaining = 0; // Reset the time remaining
        isTimerRunning = true; // Start the timer
    }

    public void StopTimer()
    {
        isTimerRunning = false; // Stop the timer
    }

    public float GetTime()
    {
        return timeRemaining; // Return the current time remaining
    }
}