/**
 * Manage the game events
 * todo: use events.
 */
using UnityEngine;

public class Game : MonoBehaviour
{
    public float maxTimeBeforeQuit; // todo: better name
    private bool isGameOver = false;
    private float timeSinceGameOver = 0;    // todo: better name

    void Update()
    {
        float timeElapsed = Time.time - timeSinceGameOver; 
        // Quit the game x seconds after the method 'gameOver' has been called.
        if (isGameOver && timeElapsed >= maxTimeBeforeQuit)
        {
            Debug.Log(timeElapsed);
            Application.Quit();
        }
    }

    
    /// <summary>
    /// Called when game is over.
    /// </summary>
    public void gameOver()
    {
        timeSinceGameOver = Time.time;
        isGameOver = true;
    }
}
