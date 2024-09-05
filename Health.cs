using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead;

    public GameObject cameraParent;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        isDead = false;
        cameraParent = Camera.main.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        this.GetComponent<DisplayHealth>().updateDisplay();
        //Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            isDead = true;
            cameraParent.GetComponent<CameraManager>().ChangeCameraMode();
            this.GetComponent<StatusCheck>().Broken();
        }

    }
}
