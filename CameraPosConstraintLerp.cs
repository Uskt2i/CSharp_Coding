using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosConstraintLerp : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 offsetPos;

    // Update is called once per frame
    void Start()
    {
        targetObject = GameObject.FindWithTag("Player");
        offsetPos = new Vector3(0f, 1.5f, 0f);
    }
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetObject.transform.position + offsetPos, 0.1f);
    }
}
