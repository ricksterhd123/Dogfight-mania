using System;
using UnityEngine;
public class PlaneDestruct : MonoBehaviour
{
    public GameObject destroyedVersion;
    private bool collided = false;
    private game g;
    public void Start()
    {
        g = FindObjectOfType<game>();
    }
    public void Update()
    {
        if (collided)
        {
            Instantiate(destroyedVersion, gameObject.transform.position, gameObject.transform.rotation);
            GameObject.Destroy(gameObject);
            collided = false;

            // Game over...
            g.gameOver();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
        collided = true;
    }
}
