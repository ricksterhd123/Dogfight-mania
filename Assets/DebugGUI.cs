using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugGUI : MonoBehaviour
{
    void OnGUI() {
        if (GUILayout.Button("Main menu")){
            SceneManager.LoadScene (sceneBuildIndex:0);
        }
    }
}
