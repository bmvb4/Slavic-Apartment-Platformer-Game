using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorScript : MonoBehaviour
{
    public bool isLocked;
    public bool InsideOpen;
    public GameObject player;
    public GameObject otherDoor;

     private Animator anim;
    void Start()
    {
        anim = transform.GetComponentInChildren<Animator>();
        anim.SetBool("inside", InsideOpen);
        anim.SetBool("isLocked", isLocked);
    }
    void Update()
    {
        if (!isLocked)
        {
            if (player!=null && Input.GetKeyDown(KeyCode.F))
                player.transform.position=otherDoor.transform.position;
        }
        anim.SetBool("isLocked", isLocked);
    }

    public void Unlock(){
        isLocked = false;
        otherDoor.GetComponentInChildren<DoorScript>().isLocked = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player = null;
    }
}
