using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    //Variable to hold Singleton object
    private Singleton singleton;
    // Update is called once per frame
    private void Update()
    {
        if(GameObject.Find("Singleton") != null){
            singleton = GameObject.Find("Singleton").GetComponent<Singleton>();
            if(singleton.relaxationSpotCount>=7&&singleton.endlessmode==false){
                StartCoroutine(S1VictoryCoroutine());
            }
        }
    }

    public IEnumerator S1VictoryCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("TheFinalChallenge");
    }
}
