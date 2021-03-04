using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed = 6;
    public float jumpspeed = 5;
    public Sprite jump;
    public Sprite stand;
    public float score = 0;
    public Text ScoreText;

    private bool Isgrounded = true;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private AudioSource audioSource1;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        rigidBody2D.velocity = new Vector2(h * speed, rigidBody2D.velocity.y);

        if(Input.GetKey(KeyCode.Space) && Isgrounded == true)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpspeed);
        }
        if (Input.GetKey(KeyCode.Space) && Isgrounded == false)
        {
            spriteRenderer.sprite = jump;
        }
        else
        {
            spriteRenderer.sprite = stand;
        }

        if (h < 0)
        {
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            spriteRenderer.flipX = true;
        }
        else if(h > 0)
        {
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * 1, transform.localScale.y, transform.localScale.z);
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base" || collision.gameObject.tag == "Base_t")
            Isgrounded = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioSource1.Play();
            Debug.Log("Collision with enemy");
            SceneManager.LoadScene("GameOver");
        }              
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base" || collision.gameObject.tag == "Base_t")
        {
            Isgrounded = false;
        }            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            Debug.Log(score);
            ScoreText.text = score.ToString();
            audioSource.Play();
            Destroy(collision.gameObject);
        }
    }
}
