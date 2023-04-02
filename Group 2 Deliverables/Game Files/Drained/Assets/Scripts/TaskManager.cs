using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    //Variable to hold task prefab
    [Header ("Task prefab")]
    [SerializeField] private GameObject taskprefab;
    //Array which holds spawn points
    [Header ("Spawnpoints array")]
    [SerializeField] private Transform[] spawnpoints;
    //Number of spots
    [Header ("Number of spots")]
    [SerializeField] private int noofspots=5;
    //List to keep track of all the tasks
    [Header ("Population")]
    private List<GameObject> population = new List<GameObject>();
    //Array which hold the spawnpoints already taken
    private List<Transform> takenSpawnPoints = new List<Transform>();

    private void Start(){
        Spawner();
    }

    private void Update(){
        CheckWin();
    }

    //Method which spawns first generation
    private void Spawner()
    {
       //Initialising population
       for(int i=0; i<noofspots; i++) {
            //Generating random spot, generating random health value and adding it to the population
           GameObject task = SpawnSpot();
           population.Add(task);
       }

    }

    //Method which spawn spots at specific way points
    private GameObject SpawnSpot(){
        bool flag =false;
        //Generating random spawnpoint
        int randSpawnPoint = Random.Range(0,spawnpoints.Length);

        //Making sure that the spot is spawned at an open spawnpoint
        do{
            flag=false;
            foreach (Transform t in takenSpawnPoints)
            {
                if (t.Equals (spawnpoints[randSpawnPoint]))
                {
                    randSpawnPoint = Random.Range(0,spawnpoints.Length);
                    flag =true;
                }
            }
        }while(flag==true);

        //Spawning spots at chosen spawnpoints
        GameObject spot = Instantiate(taskprefab,spawnpoints[randSpawnPoint].position,Quaternion.identity);
        spot.transform.parent = this.transform;
        //Adding spawnpoint to takenSpawnPoints list
        takenSpawnPoints.Add(spawnpoints[randSpawnPoint]);
        //Returning spot
        return spot;
    }

    //Method which checks if player touched all tasks
    private void CheckWin(){
        int noofdeadcounter=0;
        for(int i=0; i<population.Count; i++) {
            if(population[i].GetComponent<TaskController>().dead==true){
                noofdeadcounter++;
            }
       }
       if(noofdeadcounter==noofspots){
            StartCoroutine(VictoryCoroutine());
       }
    }

     public IEnumerator VictoryCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Victory");
    }

}
