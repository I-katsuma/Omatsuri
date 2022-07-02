using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{

    public void AddScoreMethod()
    {
        ScoreManager.Instance.Score += 10;
    }
    
}
