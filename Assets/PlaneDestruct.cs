/**
 *  Invoke gameOver when the user has crashed and display a broken aircraft.
 */
using System;
using UnityEngine;
public class PlaneDestruct : MonoBehaviour
{
    public GameObject destroyedVersion;
    private bool collided = false;
    private Game g;

    public void Start()
    {
        g = FindObjectOfType<Game>();
    }

    public void Update()
    {
        // Replace the current plane with a broken one and let the physics do the work...
        if (collided)
        {
            Instantiate(destroyedVersion, gameObject.transform.position, gameObject.transform.rotation);
            GameObject.Destroy(gameObject);
            collided = false;

            // TODO: back to main menu
            // Invoke game over...
            g.gameOver();
            Debug.Log("Did game over");
        }
    }

    // For now, any collision is regarded as a crash
    void OnCollisionEnter(Collision collision)
    {
        collided = true;
    }
}
