using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
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
        var h = Input.GetAxis("Horizontal");
        //var v = Input.GetAxis("Vertical");

        rigidBody2D.velocity = new Vector2(h * speed, rigidBody2D.velocity.y);
        //rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, v * speed);

        if (h < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            //spriteRenderer.flipX = true;
        }
        else if(h > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * 1, transform.localScale.y, transform.localScale.z);
            //spriteRenderer.flipX = false;
        }
    }
}
