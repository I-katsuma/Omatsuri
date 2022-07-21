using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prizeState : MonoBehaviour
{

    public Text scoreText;

    bool maxValue = false;

    // Start is called before the first frame update
    void Start()
    {
        maxValue = false;

        if(scoreText.text == "200" || scoreText.text == "180")
        {
            maxValue = true;            
        }
    }

    private void Update() 
    {
        if(maxValue)
        {
            scoreText.color = Color.HSVToRGB(Time.time % 1, 1, 1);
        }    
    }
}
