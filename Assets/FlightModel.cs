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
    public float XDrag, YDrag, ZDrag;        // Medium, high, and low, respectively
    public float maxSpeed;
    private Rigidbody rb;
    private bool engineOn = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, 2f, 0);
    }

    // Update is called once per frame
    // TODO: Make flight model more realistic
    void Update()
    {

        // Shut off engines
        if (Input.GetKeyDown("o"))
        {
            engineOn = false;
        }
        if (Input.GetKeyDown("i"))
        {
            engineOn = true;
        }

        // Engine throttle
        if (engineOn)
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        speed = Math.Min(maxSpeed, Math.Max(0, speed + Input.GetAxis("Throttle")));
        // Yaw
        rb.AddForceAtPosition(-transform.right * yawSpeed * Input.GetAxis("Yaw"), transform.position - transform.forward * 0.5f, ForceMode.Impulse);
        // Pitch
        rb.AddForceAtPosition(transform.up * pitchSpeed * Input.GetAxis("Pitch"), transform.position - transform.forward * 3 + transform.right * 2);
        rb.AddForceAtPosition(transform.up * pitchSpeed * Input.GetAxis("Pitch"), transform.position - transform.forward * 3 + transform.right * -2);
        // Roll
        rb.AddRelativeTorque(Vector3.forward * rollSpeed * Input.GetAxis("Roll"), ForceMode.Impulse);
        // Aerodynamic lift
        rb.AddForceAtPosition(-transform.up * Math.Max((speed - maxSpeed) / maxSpeed, 0), transform.TransformPoint(rb.centerOfMass) - transform.forward * 1f, ForceMode.Impulse);
        // Aerodynamic drag - by Pyrian#7263 on the official unity discord at #physics
        // Separate drag values for each axis
        // Divvy the velocity up by axis
        Vector3 rightVelocity = Vector3.Project(rb.velocity, transform.right);
        Vector3 upVelocity = Vector3.Project(rb.velocity, transform.up);
        Vector3 forwardVelocity = Vector3.Project(rb.velocity, transform.forward);

        // Add up the drag on each axis. Drag is proportional to the square magnitude of the velocity.
        Vector3 drag = rightVelocity.magnitude * rightVelocity * XDrag;
        drag += upVelocity.magnitude * upVelocity * YDrag;
        drag += forwardVelocity.magnitude * forwardVelocity * ZDrag;

        // Apply (drag opposes velocity, so minus)
        rb.AddForce(-drag);
    }
}
