using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    public int itemId;
    public int thisScore;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (this.transform.childCount == 2)
        {
            ScoreManager.Instance.Score += thisScore;
            //Debug.Log("現在のSCORE : " + ScoreManager.Instance.Score);
        }
    }

    private void Update() { }
}
