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
    public bool isGrab = false;

    void Update()
    {
        bool flag=false;
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right*transform.localScale.x, rayDist);
        Item = grabCheck.collider;
        if (grabCheck.collider != null && grabCheck.collider.tag == "Grab")
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && !flag){
                isGrab = !isGrab;
                flag = true;
            }
            if(Input.GetKeyUp(KeyCode.Space) && flag)
                    flag = false;
        }
        if (isGrab == true)
            {
                grabCheck.collider.gameObject.transform.parent = holder;
                grabCheck.collider.gameObject.transform.position = holder.position;
               grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }else{
                if(grabCheck.collider != null){
                    grabCheck.collider.gameObject.transform.parent = null;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
                
            }
    }
}
