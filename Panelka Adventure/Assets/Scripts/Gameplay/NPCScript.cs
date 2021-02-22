using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
        public Transform player;
        public float agroRange;
        public float speed; 
        private Rigidbody2D rb2d;
        private Animator anim;
        private SpriteRenderer SR;

    void Start()
    {
         rb2d = GetComponent<Rigidbody2D>();
         SR = transform.GetComponentInChildren<SpriteRenderer>();
         anim = transform.GetComponentInChildren<Animator>();
         
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distToPlayer <= agroRange)
        {
            ChasePlayer();
        }else
        {
            StopChasePlayer();
        }
    }

    void ChasePlayer(){
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(speed, 0);
            SR.flipX = false;
            anim.SetBool("IsWalking", true);
        }else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-speed, 0);
            anim.SetBool("IsWalking", true);
            SR.flipX = true;
        }
    }

    void StopChasePlayer()
    {
        rb2d.velocity = new Vector2(0,0);
        anim.SetBool("IsWalking", false);
    }
}
