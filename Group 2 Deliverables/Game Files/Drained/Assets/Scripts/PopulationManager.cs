using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager : MonoBehaviour
{   
    //Variable to hold spot prefab
    [Header ("Spot prefab")]
    [SerializeField] private GameObject [] spotprefabs;
    //Population size
    [Header ("Number of spots/population size")]
    public int populationsize=5;
    //List to keep track of all the spots
    [Header ("Population")]
    public List<GameObject> population = new List<GameObject>();
    //Variable to act as a flag
    [Header ("Checking flag")]
    public bool CheckFlag=true;

    //Array which holds spawn points
    [Header ("Spawnpoints array")]
    [SerializeField] private Transform[] spawnpoints;
    //Array which hold the spawnpoints already taken
    private List<Transform> takenSpawnPoints = new List<Transform>();


    //Method which spawns first generation
    public void SpawnGen1()
    {
       //Initialising population
       for(int i=0; i<populationsize; i++) {
            //Generating random spot, generating random health value and adding it to the population
           GameObject spot = SpawnSpot();
           spot.GetComponent<DNA>().health=Random.Range(10,77);
           population.Add(spot);
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
        GameObject spot = Instantiate(spotprefabs[Random.Range(0,spotprefabs.Length)],spawnpoints[randSpawnPoint].position,Quaternion.identity);
        spot.transform.parent = this.transform;
        //Adding spawnpoint to takenSpawnPoints list
        takenSpawnPoints.Add(spawnpoints[randSpawnPoint]);
        //Returning spot
        return spot;
    }

    //Method to breed population
    public void BreedPopulation(){

        //Creating a new list and intialising it to the population in descending order by health
        List<GameObject> sortedpopulation=population.OrderBy((p)=>p.GetComponent<DNA>().health).ToList();
        //Clearing population
        for(int i=0; i<population.Count; i++) {
            Destroy(population[i]);
        }
        population.Clear();
        takenSpawnPoints.Clear();

        //Adding new spawnpoints to the population
        for(int i=0; i<sortedpopulation.Count; i++) {
        if(population.Count==populationsize){
            break;
          }
          population.Add(Breed(sortedpopulation[i],sortedpopulation[i+1]));
          if(population.Count==populationsize){
            break;
          }
          population.Add(Breed(sortedpopulation[i+1],sortedpopulation[i]));
       }

    }

    //Method which breeds new spot from 2 parents
    private GameObject Breed(GameObject parent1, GameObject parent2){
        //Mutation, spawning new spot at a new position
        //Getting new spawnpoint for offspring and getting the dna for both of the parents
        GameObject offspring =SpawnSpot();
        DNA dna1 = parent1.GetComponent<DNA>();
        DNA dna2 = parent2.GetComponent<DNA>();
        //Crossover, randomly choosing to take health from one of the parents
        offspring.GetComponent<DNA>().health= Random.Range(0,7)<4 ? dna1.health : dna2.health;
        //Returning offspring
        return offspring;
    }

    //Method which hides generation
    public void HideGen(){
        //Making instances of population invisible
        for(int i=0; i<population.Count; i++) {
            population[i].GetComponent<DNA>().spriteRenderer.enabled=false;
            population[i].GetComponent<DNA>().collider.enabled=false; 
         } 
    }

    //Method which shows generation
    public void ShowGen(){
        //Making instances of population visible, if they are not dead spots
        for(int i=0; i<population.Count; i++) {
            if(population[i].GetComponent<DNA>().dead==false){
                population[i].GetComponent<DNA>().spriteRenderer.enabled=true;
                population[i].GetComponent<DNA>().collider.enabled=true;  
            }   
        }
    }

}
