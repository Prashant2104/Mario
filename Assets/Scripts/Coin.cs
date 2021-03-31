using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int c = 5;
    public AudioSource audioSource;

    private int count = 0;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Coin_up()
    {
        if (count < c)
        {
            count++;
            animator.SetBool("Jump", true);
            Player.score++;
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
        }
    }
}
