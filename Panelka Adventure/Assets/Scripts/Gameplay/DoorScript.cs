using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorScript : MonoBehaviour
{

    public bool isLocked;
    public bool isKey;
    public bool isButton;
    public GameObject keyItem;
    public GameObject buttonItem;


    void Update()
    {
        if (isLocked)
        {
            transform.GetComponentInChildren<BoxCollider2D>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
            }
            if (isButton)
            {
                GameObject thePlayer = GameObject.Find("Player");
                GrabScript grabScript = thePlayer.GetComponent<GrabScript>();
                if (grabScript.isDoorButton)
                    isLocked = false;
            }
            if (isKey)
            {
                GameObject thePlayer = GameObject.Find("Player");
                GrabScript grabScript = thePlayer.GetComponent<GrabScript>();
                if (grabScript.isKey)
                    isLocked = false;
            }
        }
        else
            transform.GetComponentInChildren<BoxCollider2D>().enabled = false;

    }
}
