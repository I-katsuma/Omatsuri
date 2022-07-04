using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> 
{
    int maxScore = 999;
    int score = 0;

    public int Score
    {
        set
        {
            score = Mathf.Clamp(value, 0, maxScore);
        }
        get
        {
            return score;
        }
    }


    private void Awake() 
    {
        if(this != Instance)
        {
            Destroy(gameObject);
            return;
        }        
        DontDestroyOnLoad(gameObject);
    }

    public void ScoreReset()
    {
        score = 0;
    }
}
