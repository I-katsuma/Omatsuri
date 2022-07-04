using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private float startTime, distance;
    private Vector3 startPosition, targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        startPosition = transform.position; // 8.75 2.9
        targetPosition = new Vector3(-8.75f, 2.9f, 0f);
        distance = Vector3.Distance(startPosition, targetPosition);

    }

    private void OnDestroy() 
    {
        Destroy(gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        float interpolatedValue = (Time.time - startTime) / distance;

        transform.position = Vector3.Lerp(startPosition, targetPosition, interpolatedValue);       

        if(transform.position.x <= -8.75f)
        {
            OnDestroy();            
        }
    }
}
