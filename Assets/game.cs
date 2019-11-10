using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{

    public float maxTimeBeforeQuit;
    private bool isGameOver = false;
    private float timeSinceGameOver = 0;

    // Update is called once per frame
    void Update()
    {
        Debug.Log((Time.time - timeSinceGameOver));
        if (isGameOver && (Time.time - timeSinceGameOver) > maxTimeBeforeQuit)
        {
            Debug.Log("Quitting...");
            Application.Quit();
        }
    }

    // Called when game is over.
    public void gameOver()
    {
        timeSinceGameOver = Time.time;
        isGameOver = true;
    }
}
