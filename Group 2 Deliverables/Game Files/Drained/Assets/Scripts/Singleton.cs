using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleton : MonoBehaviour
{

    //Variables which will be used to output final message
    [Header ("Player Relaxation Spots")]
    public int relaxationSpotCount=0;
    [Header ("Player Task Number")]
    public int taskNumber=0;
    [Header ("Endless Mode flag")]
    public bool endlessmode=false;
    [Header ("Clear Singleton flag")]
    public bool clearSingleton=false;
    

    //Destroying objects if there are many Singletons
    private void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Singleton");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        //Default values for variables:
        relaxationSpotCount=0;
        taskNumber=0;
        endlessmode=false;
        clearSingleton=false;
    }

    //Update which is constructing the end message or clearing Singleton
    private void Update(){
        if(clearSingleton==true){
            ClearSingleton();
        }
    }


    //Method which reintialises Singleton to original values
    private void ClearSingleton(){
        relaxationSpotCount=0;
        taskNumber=0;
        clearSingleton=false;
    }
}
