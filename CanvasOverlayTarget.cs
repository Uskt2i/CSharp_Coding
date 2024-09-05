using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOverlayTarget : MonoBehaviour
{
    [SerializeField]
    public Transform targetTransform;
    private RectTransform myRectTransform;
    private Vector3 offset = new Vector3(0f, 0f, 0f);

    public Camera TargetCamera;
    // Start is called before the first frame update
    void Awake()
    {
        TargetCamera = Camera.main;

        GameObject parentCanvas = this.transform.parent.gameObject;
        parentCanvas.SetActive(false);
        myRectTransform = GetComponent<RectTransform>();
        targetTransform = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetTransform != null)
        { 
        myRectTransform.position = Vector2.Lerp(this.transform.position, RectTransformUtility.WorldToScreenPoint(Camera.main, targetTransform.position + offset), 0.1f);
        }
    }
    public void ChangeTarget()
    {
        //Debug.Log("connect!");
        GameObject test = TargetCamera.transform.parent.GetComponent<CameraLockOn>().TargetEnemy;
        targetTransform = test.transform;
        //Debug.Log(test);
    }
}
