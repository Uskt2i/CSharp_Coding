using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public GameObject targetObject;
    public Camera TargetCamera;
    public Rigidbody rb;

    private bool isDash;

    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("CubePlayer");
        TargetCamera = Camera.main;
        rb = targetObject.GetComponent<Rigidbody>();
        isDash = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && isDash == false)
        {
            StartCoroutine("DashC");
        }
    }
    IEnumerator DashC()
    {
        float speed = rb.velocity.magnitude;
        Vector3 moveDir = targetObject.GetComponent<PlayerMove>().moveForward;

        rb.velocity = moveDir * 50f;
        isDash = true;
        targetObject.GetComponent<TrailRenderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        isDash = false;
        targetObject.GetComponent<TrailRenderer>().enabled = false;
    }

}
