using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.velocity = new Vector2(-speed, rigidBody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base_t")
        {
            transform.position = new Vector2(transform.position.x + 60, transform.position.y);
        }
    }
}
