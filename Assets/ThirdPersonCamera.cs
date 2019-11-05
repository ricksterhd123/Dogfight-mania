using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject attached;
    private Rigidbody rb;
    private Vector3 worldUp = new Vector3(0, 1, 0);

    private void Start()
    {
        rb = attached.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (attached != null)
        {
            transform.position = rb.transform.position - (rb.transform.forward * 20) + (worldUp * 5);
            transform.LookAt(rb.transform);
        }
    }
}
