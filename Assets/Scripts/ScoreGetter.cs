using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGetter : MonoBehaviour
{
    [SerializeField] Text scoreText;

    [SerializeField] GameObject[] getItems;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text =  ScoreManager.Instance.Score.ToString("d3");
    }

    private void FixedUpdate() {
        scoreText.text =  ScoreManager.Instance.Score.ToString("d3");

        if(ScoreManager.Instance.getItems.Count > 0)
        {

        }
    }


}
