using System;
using UnityEngine;
public class FlightModel : MonoBehaviour
{
    // Need to use forces instead of 'speeds'
    public float speed;           
    public float rollSpeed;         // Angular
    public float pitchSpeed;
    public float yawSpeed;
    public float lift;

    // Local axis vectors
    private Vector3 up = new Vector3(0, 1, 0);
    private Vector3 forward = new Vector3(0, 0, 1);
    private Vector3 right = new Vector3(1, 0, 0);

    private Rigidbody rb;
    private bool toggle = true;

    // Line drawing for debug purposes
    private GameObject velocityLineObject;
    private LineRenderer velocityLine;
    // Center of mass
    private GameObject COMLineObject;
    private LineRenderer COMLine;
    // Center of lift
    private GameObject COLLineObject;
    private LineRenderer COLLine;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.centerOfMass = new Vector3(0, 0, 8);
        velocityLineObject = new GameObject("Line");
        velocityLine = velocityLineObject.AddComponent<LineRenderer>();
        velocityLine.startWidth = 1;
        velocityLine.endWidth = 1;
        velocityLine.startColor = new Color(255, 0, 0);
        velocityLine.endColor = new Color(0, 255, 0);
        velocityLine.positionCount = 2;

        COMLineObject = new GameObject("Line");
        COMLine = COMLineObject.AddComponent<LineRenderer>();
        COMLine.startWidth = 1;
        COMLine.endWidth = 1;
        COMLine.startColor = new Color(0, 255, 0);
        COMLine.endColor = new Color(0, 255, 0);
        COMLine.positionCount = 2;

        COLLineObject = new GameObject("Line");
        COLLine = COLLineObject.AddComponent<LineRenderer>();
        COLLine.startWidth = 1;
        COLLine.endWidth = 1;
        COLLine.startColor = new Color(255, 0, 0);
        COLLine.endColor = new Color(255, 0, 0);
        COLLine.positionCount = 2;

        rb.centerOfMass = new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    // TODO: Make flight model more realistic
    void Update()
    {
        //Debug.Log(rb.centerOfMass);
        // Shut off engines
        if (Input.GetKeyDown("o"))
        {
            toggle = !toggle;
        }

        // TODO: Rotate velocity normal to rotation
        if (toggle)
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        rb.AddForceAtPosition(-transform.up * Math.Max((speed - 100) / 100, 0.1f), transform.position + transform.TransformDirection(rb.centerOfMass) - transform.forward * 1f, ForceMode.Impulse);

        //Debug.Log(rb.velocity.magnitude);

        // Apply torque for pitch, roll and yaw
        //rb.AddRelativeTorque(up * yawSpeed * Input.GetAxis("Yaw"), ForceMode.Impulse);
        rb.AddForceAtPosition(-transform.right * yawSpeed * Input.GetAxis("Yaw"), transform.position + transform.forward, ForceMode.Impulse);
        //rb.AddRelativeTorque(right * pitchSpeed * Input.GetAxis("Pitch"), ForceMode.Impulse);
        rb.AddForceAtPosition(transform.up * pitchSpeed * Input.GetAxis("Pitch"), transform.position - transform.forward * 3 + transform.right * 2);
        rb.AddForceAtPosition(transform.up * pitchSpeed * Input.GetAxis("Pitch"), transform.position - transform.forward * 3 + transform.right * -2);
        rb.AddRelativeTorque(forward * rollSpeed * Input.GetAxis("Roll"), ForceMode.Impulse);

        //velocityLine.SetPosition(0, transform.position);
        //velocityLine.SetPosition(1, transform.position + rb.velocity);
        //COMLine.SetPosition(0, transform.position);
        //COMLine.SetPosition(1, transform.position + rb.centerOfMass - transform.up * 5);

        //rb.velocity
        speed = Math.Min(200, Math.Max(0, speed + Input.GetAxis("Throttle")));
    }
}
