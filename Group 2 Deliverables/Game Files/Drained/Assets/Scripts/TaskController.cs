using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{   
    //Variables needed to make spot invisible after collision
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D collider;  
    //Variable to hold Singleton object
    private Singleton singleton;
    public bool dead =false;

    private AudioSource taskSource;


    private void Start(){
        //Initialising components
        spriteRenderer= GetComponent<SpriteRenderer>();
        collider= GetComponent<BoxCollider2D>();
        spriteRenderer.enabled=true;
        collider.enabled=true;
        taskSource = GetComponent<AudioSource>();
    }

    //Checking whether player collided with spot
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {   
            spriteRenderer.enabled=false;
            collider.enabled=false;
            //Destroying game object
            dead=true;
            //Retrieving the Singleton object and incrementing the score
            if(GameObject.Find("Singleton") != null){
                singleton = GameObject.Find("Singleton").GetComponent<Singleton>();
                singleton.taskNumber++; 
            }
            taskSource.Play();
        }
        
    }
}
