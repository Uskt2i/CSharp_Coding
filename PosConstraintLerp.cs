using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosConstraintLerp : MonoBehaviour
{
    public GameObject targetObject;

    // Update is called once per frame
    void Start()
    {
        targetObject = GameObject.Find("Player");
    }
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetObject.transform.position, 0.1f);
    }
}
