using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZankiManager : MonoBehaviour
{
    [SerializeField]
    GameObject arrowPrefab;
    public int arrowNum;
    private const int MaxArrow = 5;
    void Start()
    {
        arrowNum = 5;
        SetLifeArrow(MaxArrow);        
    }

    public void SetLifeArrow(int life)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);   
        }

        for (int i = 0; i < life; i++)
        {
            Instantiate<GameObject>(arrowPrefab, transform);   
        }
    }


    public void RadeceLifeArrow(int reduce)
    {
        for (int i = 0; i < reduce; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
            arrowNum--;
        }
    }
}
