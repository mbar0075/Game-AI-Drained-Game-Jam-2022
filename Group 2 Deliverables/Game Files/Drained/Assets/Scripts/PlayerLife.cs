using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //Declaring variables
    private Rigidbody2D rb;
    private Animator anim;

    //Variable to hold Singleton object
    private Singleton singleton;

    //Death sound
    [Header ("Death Sound")]
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource backgroundMusic;


    private void Start()
    {
        //Initialising variables
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        backgroundMusic.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   //When player touches Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
        //When player touches Trap
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    //Method which is called when player dies
    private void Die()
    {
        backgroundMusic.Stop();
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        StartCoroutine(RetryCoroutine());
    }

    public IEnumerator RetryCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Retry");
    }

    private void EndLevel(){
        SceneManager.LoadScene("End Scene");
    }

}