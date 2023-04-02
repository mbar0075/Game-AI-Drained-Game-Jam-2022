using UnityEngine;  
using UnityEngine.SceneManagement;  

public class SceneChanger: MonoBehaviour {  

    //Variable to hold Singleton object
    private Singleton singleton;

    public void ChangeSceneTo(string sceneName) { 
        SceneManager.LoadScene(sceneName);  
    }  

    public void SetEndlessModeFlag(string sceneName) { 
        if(GameObject.Find("Singleton") != null){
            singleton = GameObject.Find("Singleton").GetComponent<Singleton>();
            singleton.endlessmode=true;
        }
        ChangeSceneTo(sceneName);   
    } 

    public void SetNormalModeFlag(string sceneName) { 
        if(GameObject.Find("Singleton") != null){
            singleton = GameObject.Find("Singleton").GetComponent<Singleton>();
            singleton.endlessmode=false;
        }
        ChangeSceneTo(sceneName); 
    } 

    public void ResetSingleton() { 
        if(GameObject.Find("Singleton") != null){
            singleton = GameObject.Find("Singleton").GetComponent<Singleton>();
            singleton.clearSingleton=true;
        }
    } 

}
