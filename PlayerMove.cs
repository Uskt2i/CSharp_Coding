using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 50.0f;
    private float moveForceMultiplier = 2f;
    public Rigidbody rb;
    public Camera TargetCamera;
    public Vector3 moveForward;

    public float addGravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        TargetCamera = Camera.main;
        this.GetComponent<TrailRenderer>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //Debug.Log(y);
        Vector3 cameraForward = Vector3.Scale(TargetCamera.transform.forward, new Vector3(1, 0, 1)).normalized;

        moveForward = cameraForward * y + TargetCamera.transform.right * x;
        Vector3 moveDir = (moveForward * speed - rb.velocity) * moveForceMultiplier;
        rb.AddForce(moveDir.x, addGravity, moveDir.z);

        if (rb.velocity.magnitude > 10f)
        {
            rb.AddForce(-rb.velocity.x * 5f, addGravity, -rb.velocity.z * 5f);
        }
    }
}
