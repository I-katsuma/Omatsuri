using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Arrow")
        {
            Debug.Log("HIT!");
        }    
    }
}
