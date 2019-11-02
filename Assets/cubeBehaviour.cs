using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBehaviour : MonoBehaviour
{
    public float speed;
    public float rollSpeed;
    public float pitchSpeed;
    public float yawSpeed;
    private Vector3 up = new Vector3(0, 1, 0);
    private Vector3 forward = new Vector3(0, 0, 1);
    private Vector3 right = new Vector3(1, 0, 0);
    private Vector3 eulerRotation;
    private float yaw, pitch, roll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.localRotation *= Quaternion.AngleAxis(yawSpeed * Input.GetAxis("Yaw") * Time.deltaTime, up);
        transform.localRotation *= Quaternion.AngleAxis(rollSpeed * Input.GetAxis("Roll") * Time.deltaTime, forward);
        transform.localRotation *= Quaternion.AngleAxis(yawSpeed * Input.GetAxis("Pitch") * Time.deltaTime, right);
    }
}
