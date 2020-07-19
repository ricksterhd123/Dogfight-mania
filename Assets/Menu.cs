using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public Button singlePlayer;
    public Button exitGame;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GUI setup");
        singlePlayer.onClick.AddListener(StartGame);
        exitGame.onClick.AddListener(ExitGame);
    }

    void StartGame() {
        Debug.Log("Starting game");
        SceneManager.LoadScene (sceneBuildIndex:1);
    }

    void ExitGame() {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
