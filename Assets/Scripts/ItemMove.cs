using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private float startTime,
        distance;
    private Vector3 startPosition,
        targetPosition;

    public float Yzahyo = 2.9f;

    //public ItemCollider itemCollider;
    public 

    void Start()
    {
        //itemCollider = GetComponent<ItemCollider>();
        startTime = Time.time;
        startPosition = new Vector3(8.75f, Yzahyo, 0f); // transform.position; // 8.75 2.9
        targetPosition = new Vector3(-8.75f, Yzahyo, 0f);
        distance = Vector3.Distance(startPosition, targetPosition);
    }

    private void OnDestroy()
    {
        //if (itemCollider.arrowCheck == true) // 矢が刺さった場合は非アクティブ化
        if(this.gameObject.transform.childCount == 3)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            // それ以外はデストロイ
            Destroy(gameObject);
        }
    }

    void Update()
    {
        float interpolatedValue = (Time.time - startTime) / distance;

        transform.position = Vector3.Lerp(startPosition, targetPosition, interpolatedValue);

        if (transform.position.x <= -8.75f)
        {
            OnDestroy();
        }
    }
}
