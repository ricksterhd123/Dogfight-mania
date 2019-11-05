using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throttleParticles : MonoBehaviour
{
    public Rigidbody attached;
    public Vector3 positionRelative;

    // Update is called once per frame
    void Update()
    {
        transform.position = attached.position + attached.transform.TransformDirection(positionRelative);
    }
}
