using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int c = 5;
    public Text ScoreText;
    public Text CoinText;

    private int count = 0;
    private AudioSource audioSource;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Special()
    {
        if (count < c)
        {
            count++;
            Player.score = Player.score + 10;
            Player.coin = Player.coin + 1;
            ScoreText.text = ("Score: " + Player.score);
            CoinText.text = ("Coins: " + Player.coin);
            spriteRenderer.enabled = true;
            animator.SetBool("Jump", true);
            audioSource.Play();
        }
    }
  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (count < c)
        {
            if (collision.gameObject.tag == "Player")
            {
                animator.SetBool("Jump", true);
                Player.score += 1;
                audioSource.Play();
                count++;
            }
        }
    }*/

   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Jump", false);
            spriteRenderer.enabled = false;
        }
    }
}
