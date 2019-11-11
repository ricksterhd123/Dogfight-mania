using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleParticles : MonoBehaviour
{
    public Rigidbody attached;
    public Vector3 positionRelative;

    void Update()
    {
        transform.position = attached.position + attached.transform.TransformDirection(positionRelative);
    }
}
