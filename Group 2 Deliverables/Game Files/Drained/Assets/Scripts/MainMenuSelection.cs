using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuSelection : MonoBehaviour
{

    [SerializeField] Button[] mm_selection;
    [SerializeField] RectTransform indicator;
    [SerializeField] float moveDelay;
    [SerializeField] float xPos;
    [SerializeField] bool pressed = false;

    int indicatorPos;
    float moveTimer;

    // Update is called once per frame
    void Update()
    {
        if(moveTimer < moveDelay)
        {
            moveTimer += Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(moveTimer >= moveDelay)
            {            
                if(indicatorPos < mm_selection.Length - 1)
                {
                    indicatorPos++;
                } 

                moveTimer = 0;
            }
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            if(moveTimer >= moveDelay)
            { 
                if(indicatorPos > 0)
                {
                    indicatorPos--;
                }
                

                moveTimer = 0;
            }
        }

        indicator.localPosition = new Vector3(xPos, mm_selection[indicatorPos].GetComponent<RectTransform>().localPosition.y, 0.0f);
        
        
        // TextMeshProUGUI text = mm_selection[indicatorPos].GetComponentsInChildren<TextMeshProUGUI>()[0];
        // text.color = new Color(255,0,0);

        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            pressed = true;              
        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            if(pressed)
            {
                pressed = false;
                mm_selection[indicatorPos].onClick.Invoke();
            }   
        }
        
    }

    public void HoverOnButton(int buttonIndex)
    {
        indicatorPos = buttonIndex;
        // TextMeshProUGUI text = mm_selection[indicatorPos].GetComponentsInChildren<TextMeshProUGUI>()[0];
        // text.color = new Color(255,0,0);
    }
}