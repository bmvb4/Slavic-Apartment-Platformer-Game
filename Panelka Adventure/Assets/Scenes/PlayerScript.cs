using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;      

    private Rigidbody2D rb2d;

    private SpriteRenderer SR;

    private bool IsFacingRight = true;
    // Use this for initialization
    void Start()
    {
        rb2d = transform.GetComponentInChildren<Rigidbody2D>();
        SR = transform.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SR.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SR.flipX = true;
        }
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * 150);
        }
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        

    }



    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed * Time.deltaTime);
    }
}
