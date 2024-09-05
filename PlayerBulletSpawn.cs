using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawn : MonoBehaviour
{
    private float power = 3000f;
    private Camera TargetCamera;
    public GameObject bullet;
    public Transform spawnPoint;
    public Vector3 offset = new Vector3(0f, 1f, 0f);

    void Start()
    {
        spawnPoint = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
        //if (input.getkeydown(keycode.space))
        //{
        //    shoot();
        //}
    }
    void Shoot()
    {
        TargetCamera = Camera.main;
        Vector3 cameraForward = Vector3.Scale(TargetCamera.transform.forward, new Vector3(1, 1, 1)).normalized;
        //GameObject newBullet = Instantiate(bullet, spawnPoint.position + new Vector3(0f, 1f, 0f), Quaternion.identity) as GameObject;
        GameObject newBullet = Instantiate(bullet, spawnPoint.position + cameraForward+offset, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rigidbody>().AddForce(cameraForward * power);
    }
}
