using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Item")
        {
            this.transform.SetParent(other.gameObject.transform);
        }    
    }


    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y > 5.55f)
        {
            Destroy(gameObject);
        }
    }
}
