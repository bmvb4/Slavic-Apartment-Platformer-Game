using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorScript : MonoBehaviour
{

    public bool isLocked;
    public bool isButton;
    public GameObject buttonItem;
    private Animator anim;

    private void Start()
    {
        anim = transform.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //isLocked = (transform.GetComponentInChildren<BoxCollider2D>().enabled == true)?true:false;

        if (isLocked)
        {
            anim.SetBool("isLocked", true);
            transform.GetComponentInChildren<BoxCollider2D>().enabled = true;
            if (isButton)
            {
                GameObject thePlayer = GameObject.Find("Player");
                GrabScript grabScript = thePlayer.GetComponent<GrabScript>();
                if (grabScript.isDoorButton)
                    isLocked = false;
            }
        }
        else{
            transform.GetComponentInChildren<BoxCollider2D>().enabled = false;
            anim.SetBool("isLocked", false);
        }
            

    }
}
