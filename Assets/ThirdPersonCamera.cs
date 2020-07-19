using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject attached;
    private Rigidbody rb;
    private Vector3 cameraFacingDirection = -Vector3.forward;
    private int cameraDistance = 50;    // units
    private float cameraHeight = 0.5f;       // units
    private void Start()
    {
        rb = attached.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (attached != null)
        {
            transform.position = rb.transform.position - rb.transform.forward * cameraDistance + Vector3.up * cameraHeight;
            transform.LookAt(rb.transform);
            transform.RotateAround(rb.transform.position, Vector3.right, 360 * Input.GetAxis("Mouse Y"));
            transform.RotateAround(rb.transform.position, Vector3.up, 360 * Input.GetAxis("Mouse X"));
        }
    }
}
