using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Camera TargetCamera;
    public bool isCameraLockOn;


    public Image imageCanvas;

    public GameObject[] enemys;
    public List<GameObject> nearEnemys = new List<GameObject>();
    public float searchDistance = 20f;
    public int enemyNumber;

    // Start is called before the first frame update
    void Start()
    {
        TargetCamera = Camera.main;
        isCameraLockOn = false;
        enemyNumber = 0;

        this.GetComponent<CameraLockOn>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            //Debug.Log("LockOn");
            isCameraLockOn = false;

            this.GetComponent<CameraThirdPersion>().enabled = true;
            this.GetComponent<CameraLockOn>().enabled = false;

            imageCanvas.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            SearchNearEnemy();
            if (enemyNumber>=1)
            {


                //Debug.Log("LockOff");
                isCameraLockOn = true;

                this.GetComponent<CameraThirdPersion>().enabled = false;
                this.GetComponent<CameraLockOn>().enabled = true;

                this.GetComponent<CameraLockOn>().SearchNearestEnemy();

                imageCanvas.transform.parent.gameObject.SetActive(true);
                imageCanvas.GetComponent<CanvasOverlayTarget>().ChangeTarget();
            }

        }
    }
    void ChangeTargetEnemy()
    {
        if (isCameraLockOn)
        {
            this.GetComponent<CameraLockOn>().ChangeTargetEnemy();
        }
        else
        {
            //Debug.Log("NotLockOn");
        }
    }
    void SearchNearEnemy()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            float dis = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (dis < searchDistance)
            {
                nearEnemys.Add(enemy);
            }
        }
        enemyNumber = nearEnemys.Count;
        nearEnemys = new List<GameObject>();
        print(enemyNumber);
    }
}
