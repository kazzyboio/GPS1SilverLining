using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
          
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {           
            Die();
        }

        else if (collision.gameObject.CompareTag("Obstacle1"))
        {
            Die();
        }

        else if (collision.gameObject.CompareTag("Obstacle2"))
        {
            Die();
        }
    }
    
    private void Die()
    {
        FindObjectOfType<SoundManager>().Play("PlayerDeath");
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Dead");
    }
   
    private void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
