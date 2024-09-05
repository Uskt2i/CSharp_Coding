using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasStatus : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;

    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
