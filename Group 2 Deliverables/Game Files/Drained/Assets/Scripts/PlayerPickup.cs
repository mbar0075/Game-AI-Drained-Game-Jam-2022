using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private AudioSource pickUpSound;
    [SerializeField] private AudioClip pickUpClip;

    public void OnCollisionEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("RelaxSpot") || collider.CompareTag("Task"))
        {
            pickUpSound.PlayOneShot(pickUpClip, 0.7f);
        }
    }
}
