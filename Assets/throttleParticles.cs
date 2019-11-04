using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throttleParticles : MonoBehaviour
{
    public Rigidbody attached;
    public Vector3 positionRelative;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = attached.position + attached.transform.TransformDirection(positionRelative);
    }
}
