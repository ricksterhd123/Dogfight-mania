using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camBehaviour : MonoBehaviour
{
    public Rigidbody attached;
    private RaycastHit rayHit;
    private Vector3 worldUp = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = attached.transform.position - (attached.transform.forward * 20) + (worldUp * 5);
        transform.LookAt(attached.transform);

        // raycast to prevent wallhack
    }
}
