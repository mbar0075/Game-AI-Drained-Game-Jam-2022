using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    
    //Variable to hold Singleton object
    private Singleton singleton;

    // Start is called before the first frame update
    private void Start()
    {
        ScoreText.GetComponent<Text>().text = "Score: 0";
    }

    // Update is called once per frame
    private void Update()
    {
        if(GameObject.Find("Singleton") != null){
            singleton = GameObject.Find("Singleton").GetComponent<Singleton>();
            float totalScore = singleton.relaxationSpotCount + singleton.taskNumber;
            ScoreText.text = "Score: "+totalScore;
        }
    }
}
