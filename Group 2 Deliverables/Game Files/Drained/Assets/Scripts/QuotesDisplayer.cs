using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuotesDisplayer : MonoBehaviour
{   
    private float time =0;
    [SerializeField] private float multiple=8;
    [SerializeField] private TextMeshProUGUI outputtext;

    private void Start(){
        outputtext.GetComponent<Text>().text="Reminder. It is helpful to keep yourself surrounded by animals.";
    }

    // Update is called once per frame
    private void Update()
    {
        time+=Time.deltaTime;
        if(time>=0f){
            outputtext.text="Reminder. It is helpful to keep yourself surrounded by animals.";
        }
        if(time>multiple){
            outputtext.text="Next time; pet a cat!";
        }
        if(time>multiple*2){
            outputtext.text="Did you know that exercising decreases stress?";
        }
        if(time>multiple*3){
            outputtext.text="Try taking a 20 minute walk!";
        }
        if(time>multiple*4){
            outputtext.text="You are what you eat; Charge up your body with the right nutrition.";
        }
        if(time>multiple*5){
            outputtext.text="Notice the difference in your mood.";
        }
        if(time>multiple*6){
            outputtext.text="Reminder; Don’t forget to take your medication or vitamins!";
        }
        if(time>multiple*7){
            outputtext.text="Try opening up! Talking to a loved one or a therapist reduces depression rates.";
            time=0;
        }
         
    }
}
