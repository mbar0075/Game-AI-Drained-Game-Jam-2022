using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class HealthBar : MonoBehaviour
{   
    [Header ("Blur Tilemap")]
    //Variable to hold blurred tilemap
    [SerializeField] private Tilemap blur;

    //Variable to hold health slider, health bar gradient and health bar image
    [Header ("Slider")]
    [SerializeField] private Slider slider;
    [Header ("Gradient")]
    [SerializeField] private Gradient gradient;
    [Header ("Fill")]
    [SerializeField] private Image fill;
    //Variables used to hold max opacity tilemap can have
    private float maxOpacity=0.9f;
    //Variable to hold the rate by which health bar decreases
    private int decreaseRate=4;

    //Variables used to hold health
    private float maxHealth=100;
    private float currentHealth;
    private float minHealth=0;

    [Header ("Population Manager")]
    //Variable to hold population Manager
    [SerializeField] private PopulationManager manager;
    //To hold the number of spots touched
    private int noOfSpots=0;

    // Start is called before the first frame update
    private void Start()
    {
        //Setting current health and max health
        currentHealth=maxHealth;
        SetMaxHealth(maxHealth);
        manager.CheckFlag=true;

        //Setting blurred tilemap color to invisible
        blur.color= new Color(186, 176, 181,0f);
    }

    // Update is called once per frame
    private void Update()
    {   
        //Calling Display Population method
        DisplayPopulation();

        //Setting currentHealth to maxHealth so that it would not overflow
        if(currentHealth>maxHealth){
            currentHealth=maxHealth;
        }
        if (currentHealth < minHealth)
        {
            currentHealth = minHealth;
        }

        //Decreasing health relative to the amount of time that passed
        currentHealth-=decreaseRate*Time.deltaTime;
        SetHealth(currentHealth);

        //Making the blurred tilemap more apparent and thus, decreasing screen visibility
        blur.color= new Color(186, 176, 181,maxOpacity-(slider.normalizedValue*maxOpacity));
 
    }


    //Function which sets health
    private void SetHealth(float health){
        slider.value=health;

        //Setting image color to gradient color relative to the slider's value
        fill.color= gradient.Evaluate(slider.normalizedValue);
    }

    //Function which sets maximum health
    private void SetMaxHealth(float health){
        slider.maxValue=health;
        slider.value=health;

        //Setting image color to max gradient color
        fill.color= gradient.Evaluate(1f);
    }

    //Function which displays the spots
    private void DisplayPopulation(){
        //Checking if current health is smaller than a certain thershold and if so will spawn the first generation
        if(currentHealth<(maxHealth/2.5)&&manager.CheckFlag==true&&noOfSpots==0){
            manager.SpawnGen1();
            manager.CheckFlag=false;//Will be used as a flag to check spots
            noOfSpots++;
        }//Checking if current health is smaller than a certain thershold and if so will eaither breed a new generation or show the current generation
        else if(currentHealth<(maxHealth/2.5)&&manager.CheckFlag==true){
            if(noOfSpots%manager.populationsize==0){
                manager.BreedPopulation();
            }
            else{
                manager.ShowGen();
            }
            manager.CheckFlag=false;
            noOfSpots++;
        }

        //Checking flag, whether the spots are showing
        if(manager.CheckFlag==false){
            //Looping through all spots and checking whether they are dead, if they are dead, deadflag2 is set to true, and all the spots are hidden
            for(int i=0; i<manager.population.Count; i++) {
                if(manager.population[i].GetComponent<DNA>().deadflag2==true&&manager.population[i].GetComponent<DNA>().dead==true){
                    currentHealth+=manager.population[i].GetComponent<DNA>().health;
                    manager.CheckFlag=true;
                    manager.population[i].GetComponent<DNA>().deadflag2=false;
                    manager.HideGen();
                }
            }      
        } 

    }

}
