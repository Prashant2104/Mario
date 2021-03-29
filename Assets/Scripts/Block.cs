using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int count = 1;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("Jump", true);
            count++;
        }

        if(count >= 5)
        {
            animator.SetBool("Count", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("Jump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(count < 5)
        {
            if (collision.gameObject.tag == "Player")
            {
                animator.SetBool("Jump", true);
                count++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Jump", false);
        }
    }
}
