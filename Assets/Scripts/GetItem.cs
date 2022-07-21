using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    public Text thisScoreText;
    
    bool maxValue = false;

    
    void Start()
    {
        maxValue = false;

        if(thisScoreText.text == "200" || thisScoreText.text == "180")
        {
            maxValue = true;            
        }
    }


    private void Update() 
    {
        if(maxValue)
        {
            thisScoreText.color = Color.HSVToRGB(Time.time % 1, 1, 1);
        }    
    }
    
}
