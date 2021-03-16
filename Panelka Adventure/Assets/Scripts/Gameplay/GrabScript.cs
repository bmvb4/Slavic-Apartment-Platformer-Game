using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public bool isDoorButton = false;
    private bool isKey = false;
    public Transform grabDetect;
    public Transform holder;
    public float rayDist;
    [Header("Info")]
    public Collider2D Item;
    public Collider2D DOOOR;
    private GameObject grabCheck;
    public bool isGrab = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGrab)
            {
                if (grabCheck != null && grabCheck.tag == "Grab")
                    isGrab = true;
                if (grabCheck != null && grabCheck.tag == "DoorButton")
                    isDoorButton = true;
                if (grabCheck != null && grabCheck.tag == "Key")
                {
                    isGrab = true;
                    isKey = true;
                }
            }
            else
            {
                if (isKey)
                {
                    //
                }
                else
                {
                    isGrab = false;
                    grabCheck.gameObject.transform.parent = null;
                    grabCheck.gameObject.AddComponent<Rigidbody2D>();
                    grabCheck.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
                    grabCheck.gameObject.GetComponent<Rigidbody2D>().mass = 100;
                }

            }
        }
        if (isGrab == true)
        {
            grabCheck.gameObject.transform.parent = holder;
            grabCheck.gameObject.transform.position = holder.position;
            if (!isKey)
                Destroy(grabCheck.gameObject.GetComponent<Rigidbody2D>());
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("TriggerEnter: " + other.gameObject);
        if(!isGrab)
            grabCheck = other.gameObject;
        if (isKey)
        {
            if (other.gameObject.tag == "Door")
            {
                isDoorButton = true;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                isGrab = false;
                isKey = false;
                Destroy(grabCheck.gameObject);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!isGrab)
            grabCheck = other.gameObject;
    }
}
