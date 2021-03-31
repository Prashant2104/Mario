using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float velocity = 6;
    public float jumpspeed = 6.5f;
    //public Sprite jump;
    //public Sprite stand;
    //public Sprite Mario_up;
    public static float score = 0;
    public int c = 1;
    public static int coin = 0;
    public Text ScoreText;
    public Text CoinText;
    public AudioClip[] clips = new AudioClip[5];
    public Sprite[] sprites = new Sprite[2];

    private float speed;
    private bool Isgrounded = true;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        rigidBody2D.velocity = new Vector2(h * speed, rigidBody2D.velocity.y);

       /* if(Input.GetKey(KeyCode.Space) && Isgrounded == true)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpspeed);
        }*/

        if (Input.GetKey(KeyCode.Space) || Isgrounded == false)
        {
            speed = velocity/2;
            animator.SetBool("Jump", true);
        }
        else
        {
            speed = velocity;
            animator.SetBool("Jump", false);
        }

        if(h <= -0.1 && Isgrounded == true || h >= 0.1 && Isgrounded == true)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (h < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(h > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base" || collision.gameObject.tag == "Base_t")
            Isgrounded = true;

        if (Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "Base" || Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "Base_t")
        {
            Vector2 direction = collision.GetContact(0).normal;
            if (direction.y == 1)
            {
                audioSource.clip = clips[3];
                audioSource.Play();
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpspeed);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetBool("Die", true);
            audioSource.clip = clips[1];
            audioSource.Play();
            Debug.Log("Collision with enemy");
            SceneManager.LoadScene("GameOver");
        }

       /* if (Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "Base" || Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "Base_t")
        {
            Vector2 direction = collision.GetContact(0).normal;
            if (direction.y == 1)
            {
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpspeed);
            }
        }*/
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
            score += 10; ;
            coin++;
            Debug.Log(score); 
            ScoreText.text = ("Score: " + score);
            CoinText.text = ("Coins: " + coin);
            audioSource.clip = clips[0]; 
            audioSource.Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Flower")
        {
            Destroy(collision.gameObject);
            spriteRenderer.sprite = sprites[0];
        }

        if (collision.gameObject.tag == "Head")
        {
            score += 5;
            Debug.Log(score);
            ScoreText.text = ("Score: " + score);
            audioSource.clip = clips[2];
            audioSource.Play();
        }

        if(collision.gameObject.tag == "Castle")
        {
            SceneManager.LoadScene("Win");
        }
    }
}