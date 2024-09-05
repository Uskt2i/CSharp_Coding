using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraThirdPersion : MonoBehaviour
{
    public float Speed = 3;

    private float m_TurnSmoothing = 10.0f;
    private float m_LookAngle;
    private float m_TiltAngle;

    private Quaternion m_TransformTargetRot;

    private float x;
    private float y;

    private void OnEnable()
    {
        Vector3 dir = this.transform.rotation.eulerAngles;
        m_LookAngle = dir.y;
        m_TiltAngle = 0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HandleRotationMovement();
        //Debug.Log("check" + m_TransformTargetRot);
    }
    private void HandleRotationMovement()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        m_LookAngle += x * Speed;
        m_TiltAngle += y * Speed;
        m_TiltAngle = Mathf.Clamp(m_TiltAngle, -5f, 30f);

        m_TransformTargetRot = Quaternion.Euler(m_TiltAngle, m_LookAngle, 0f);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, m_TransformTargetRot, m_TurnSmoothing * Time.deltaTime);
    }
}
