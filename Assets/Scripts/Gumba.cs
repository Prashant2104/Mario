using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumba : MonoBehaviour
{
    public float speed = 4;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Base_t")
        {
            speed = speed * -1;
           // spriteRenderer.flipX = false;
            transform.localScale = new Vector3((transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }

        if (collision.gameObject.tag == "Base_t1")
        {
            speed = speed * -1;
            //spriteRenderer.flipX = true;
            transform.localScale = new Vector3((transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base_t")
        {
            speed = speed * -1;
            //spriteRenderer.flipX = false;
            transform.localScale = new Vector3((transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
