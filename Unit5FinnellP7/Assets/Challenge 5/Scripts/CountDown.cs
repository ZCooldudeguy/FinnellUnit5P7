using UnityEngine;
using UnityEngine.UI; // Use TMPro if using TextMeshPro
using UnityEngine.SceneManagement;

public partial class TimerController : MonoBehaviour
{
    public float timeRemaining = 60; // Set starting time in seconds
    public bool timerIsRunning = false;
    public Text timeText; // Drag your UI Text component here

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Subtract the time between frames
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameOverR();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Makes it feel more natural by rounding up
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOverR()
    {
        // Option 1: Load a Game Over scene (ensure it's in Build Settings)
        // SceneManager.LoadScene("GameOverScene");

        // Option 2: Stop time in the current scene
        Time.timeScale = 0; 
        
        // Option 3: Quit the application (only works in a built game)
        // Application.Quit();
        
        Debug.Log("Game Over Triggered");
    }
}