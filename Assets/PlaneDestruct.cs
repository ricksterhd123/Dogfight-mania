using System;
using UnityEngine;
public class PlaneDestruct : MonoBehaviour
{
    public GameObject destroyedVersion;
    private bool collided = false;

    public void Update()
    {
        if (collided)
        {
            Instantiate(destroyedVersion, gameObject.transform.position, gameObject.transform.rotation);
            GameObject.Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
        collided = true;
    }
}
