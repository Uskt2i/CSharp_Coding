using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Camera TargetCamera;
    public bool isCameraLockOn;
    public GameObject cameraParent;

    public Image imageCanvas;

    public GameObject[] enemys;
    public List<GameObject> nearEnemys = new List<GameObject>();
    public float searchDistance=10f;

    void Start()
    {

        TargetCamera = Camera.main;
        isCameraLockOn = false;

        cameraParent = TargetCamera.transform.parent.gameObject;

        cameraParent.GetComponent<CameraLockOn>().enabled = false;

        //imageCanvas.GetComponent<UIControllerOverlay>().enabled = false;
    }
    void Update()
    {
        //Debug.Log(isCameraLockOn);
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeCameraMode();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("change");
            ChangeTargetEnemy();
        }
    }

    public void ChangeCameraMode()
    {

        //Debug.Log("pushE");
        if (isCameraLockOn == true)
        {
            isCameraLockOn = false;
            //Debug.Log("LockOn");
            cameraParent.GetComponent<CameraThirdPersion>().enabled = true;
            cameraParent.GetComponent<CameraLockOn>().enabled = false;

            imageCanvas.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            //Debug.Log("LockOff");
            isCameraLockOn = true;

            cameraParent.GetComponent<CameraThirdPersion>().enabled = false;
            cameraParent.GetComponent<CameraLockOn>().enabled = true;

            cameraParent.GetComponent<CameraLockOn>().SearchNearestEnemy();

            imageCanvas.transform.parent.gameObject.SetActive(true);
            imageCanvas.GetComponent<CanvasOverlayTarget>().ChangeTarget();

        }
    }
    void ChangeTargetEnemy()
    {
        if (isCameraLockOn)
        {
            cameraParent.GetComponent<CameraLockOn>().ChangeTargetEnemy();
        }
        else
        {
            //Debug.Log("NotLockOn");
        }
    }
    void SearchNearEnemy(int enemyNumber)
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemys)
        {
            float dis = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (dis < searchDistance)
            {
                nearEnemys.Add(enemy);
            }
        }
        enemyNumber = nearEnemys.Count;
        print(enemyNumber);
    }
}
