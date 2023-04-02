using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DNA : MonoBehaviour
{   
    [Header ("SpriteRenderer and Collider")]
    //Variables needed to make spot invisible after collision
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D collider;
    [Header ("Health")]
    //Variable that holds health
    public float health;
    [Header ("dead state")]
    //Variables to check whether spot is dead, dead shows the state of the object, whilst, deadflag2 acts as a flag
    public bool dead = false;
    [Header ("dead flag")]
    public bool deadflag2 = false;

    //Variable to hold Singleton object
    private Singleton singleton;
    private AudioSource RSSoundEffect;


    private void Start(){
        //Initialising components
        spriteRenderer= GetComponent<SpriteRenderer>();
        collider= GetComponent<BoxCollider2D>();
        spriteRenderer.enabled=true;
        collider.enabled=true;
        RSSoundEffect = GetComponent<AudioSource>();
        
    }


    //Checking whether player collided with spot
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {   
            //Making spot invisible and setting respective flags
            dead=true;
            deadflag2=true;
            spriteRenderer.enabled=false;
            collider.enabled=false;
            //Retrieving the Singleton object and incrementing the score
            if(GameObject.Find("Singleton") != null){
                singleton = GameObject.Find("Singleton").GetComponent<Singleton>();
                singleton.relaxationSpotCount++;
            }
        }
        RSSoundEffect.Play();
    }
}
