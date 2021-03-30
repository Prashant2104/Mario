using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //public float speed = 4;
    public int count = 1;

    private Animator animator;
    //private Rigidbody2D rigidBody2D;
    //Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       // rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, speed);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
            //animator.SetBool("Jump", true);
            count++;
        }

        if (count >= 5)
        {
            animator.SetBool("Count", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            //animator.SetBool("Jump", false);
        }
    }
}