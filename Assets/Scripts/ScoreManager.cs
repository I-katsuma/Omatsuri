using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> 
{
    int maxScore = 999;
    int score = 0;

    public List<GameObject> getItems = new List<GameObject>();

    public int Score
    {
        set
        {
            // 範囲内に収めた値=Mathf.Clamp(範囲内に指定したい値,最小値,最大値);
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

    private void Start() {
        score = 0;
    }

    public void ScoreReset()
    {
        score = 0;
    }
}
