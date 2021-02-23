using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public Transform grabDetect;
    public Transform holder;
    public float rayDist;
    [Header("Info")]
    public Collider2D Item;
    RaycastHit2D grabCheck;
    public bool isGrab = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGrab)
            {
                grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist);
                Item = grabCheck.collider;
                if (grabCheck.collider != null && grabCheck.collider.tag == "Grab")
                {
                    isGrab = true;
                }

            }
            else
            {
                isGrab = false;
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.AddComponent<Rigidbody2D>();
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().mass = 100;
            }
        }
        if (isGrab == true)
        {
            grabCheck.collider.gameObject.transform.parent = holder;
            grabCheck.collider.gameObject.transform.position = holder.position;
            Destroy(grabCheck.collider.gameObject.GetComponent<Rigidbody2D>());
        }

    }
}
