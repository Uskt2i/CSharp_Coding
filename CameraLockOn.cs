using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLockOn : MonoBehaviour
{
    public GameObject TargetEnemy;
    public GameObject[] enemys;
    //public GameObject[] withInEnemys;

    public Image imageCanvas;

    //private float Range = 10f;
    private float minDis = 1000f;
    public int enemyID;

    void Awake()
    {
        TargetEnemy = null;
        enemyID = 0;
        SearchNearestEnemy();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = TargetEnemy.transform.position - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        //Debug.Log(enemys.Length);
    }

    public void SearchNearestEnemy()
    {

        enemyID = 0;
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject player = GameObject.FindWithTag("Player");
        int x = 0;
        foreach (GameObject enemy in enemys)
        {
            float dis = Vector3.Distance(player.transform.position, enemy.transform.position);

            if (dis < minDis)
            {
                minDis = dis;
                TargetEnemy = enemy;
            }
            //imageCanvas.GetComponent<UIControllerOverlay>().ChangeTarget();
            x += 1;
        }
        minDis = 1000f;
    }

    public void ChangeTargetEnemy()
    {
        int numEnemy = enemys.Length;
        enemyID += 1;
        if (enemyID >= numEnemy) enemyID = 0;
        TargetEnemy = enemys[enemyID];

        imageCanvas.GetComponent<CanvasOverlayTarget>().ChangeTarget();
    }
    public void CheckTarget()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemys[0]);
        Debug.Log(enemys.Length);
        if(enemys[0] == null)
        {


            Debug.Log("ok");
        }
    }
}
