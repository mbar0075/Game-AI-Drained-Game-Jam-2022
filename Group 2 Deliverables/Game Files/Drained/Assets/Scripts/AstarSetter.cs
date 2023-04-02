using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarSetter : MonoBehaviour
{
    //Variables which hold Astar object and enemy object
    [Header("Astar Object")]
    [SerializeField] private GameObject AstarObject;
    [Header("Enemies Array")]
    [SerializeField] private GameObject[] Enemies;

    // Update is called once per frame
    private void Update()
    {   
        //Setting enemies to active if astar is active
        if(AstarObject.activeSelf  == true){
            for(int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i].SetActive(true);
            }
        }
    }

}
