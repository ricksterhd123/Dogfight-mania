using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DebugGUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
        if (GUILayout.Button("Press Me")){
            //Debug.Log("Hello!");
            SceneManager.LoadScene (sceneBuildIndex:0);
        }
    }
}
