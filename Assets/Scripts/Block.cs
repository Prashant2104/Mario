using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int c = 0;

    private int count = 0;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 direction = collision.GetContact(0).normal;
            if (direction.y == 1)
            {
                if (count < c)
                {
                    animator.SetBool("Jump", true);
                    this.gameObject.GetComponentInChildren<Coin>().Special();
                    count++;
                }
            }
        }

        if (count >= c)
        {
            animator.SetBool("Count", true);
            spriteRenderer.enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Jump", false);
        }
    }
}