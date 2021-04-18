using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : MonoBehaviour
{
    [Header("Info")]
    public bool isLocked;
    public GameObject Door;
    private Animator anim;
    public bool pressed = false;
    void Start()
    {
        anim = Door.GetComponentInChildren<Animator>();
        anim.SetBool("isLocked", isLocked);
    }

    void Update()
    {
        isLocked = Door.GetComponentInChildren<DoorScript>().isLocked;
        if (isLocked)
        {
            anim.SetBool("isLocked", true);
            //Door.GetComponentInChildren<BoxCollider2D>().enabled = true;
            if (pressed && Input.GetKeyDown(KeyCode.Space))
                Door.GetComponentInChildren<DoorScript>().Unlock();
        }
        else{
           //Door.GetComponentInChildren<BoxCollider2D>().enabled = false;
            anim.SetBool("isLocked", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        pressed = true; 
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        pressed = false;
    }


}
