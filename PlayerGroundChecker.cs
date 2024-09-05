using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGroundChecker : MonoBehaviour
{
    public UnityEvent OnEnterGround;
    public UnityEvent OnExitGround;

    //private int enterNum =0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(enterNum);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")==false)
            { 
                //Debug.Log("OnGround");
                //enterNum++;
                OnEnterGround.Invoke();
            }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")==false)
        { 
            //Debug.Log("ExitGround");
            OnExitGround.Invoke();
        }


        // enterNum--;
        //if (enterNum <= 0)
        //{

        //}
    }
}
