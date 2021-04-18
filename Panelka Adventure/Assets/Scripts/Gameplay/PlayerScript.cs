using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    private SpriteRenderer SR;

    private Animator anim;
    private float moveHorizontal = 0f;
    // Use this for initialization
    void Start()
    {
        rb2d = transform.GetComponentInChildren<Rigidbody2D>();
        SR = transform.GetComponentInChildren<SpriteRenderer>();
        anim = transform.GetComponentInChildren<Animator>();
    }


    void Update()
    {

        moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;
        if (Mathf.Abs(moveHorizontal) > 0 && rb2d.velocity.y == 0)
            anim.SetBool("IsWalking", true);
        else
            anim.SetBool("IsWalking", false);

        if (Input.GetKeyDown(KeyCode.UpArrow) && rb2d.velocity.y == 0)
        {
            rb2d.AddForce(Vector2.up * 350);
        }

        if (rb2d.velocity.y == 0)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }
        if (rb2d.velocity.y > 0)
            anim.SetBool("IsJumping", true);

        if (rb2d.velocity.y < 0)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", true);
        }

        //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    }
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveHorizontal, rb2d.velocity.y);
    }

    private void LateUpdate()
    {
        if (moveHorizontal > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (moveHorizontal < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
