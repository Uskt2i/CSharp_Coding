using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject jumpFX;

    public bool OnGround { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        OnGround = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&OnGround)
        {
            JumpY();
            //Debug.Log("jump!");
        }
        //Debug.Log(OnGround);
    }
    void JumpY()
    {
        rb.velocity = new Vector3(0, 20f, 0);
        GameObject newJumpFX = Instantiate(jumpFX, this.transform.position, Quaternion.identity) as GameObject;
        //OnGround = false;
    }
}
