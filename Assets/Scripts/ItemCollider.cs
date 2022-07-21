using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    public int itemId;
    public int thisScore;

    //public bool arrowCheck;

    [SerializeField]
    GameObject thisObject;
    [SerializeField] Collider2D myCollider;

    private void Start()
    {
        //arrowCheck = false;
        myCollider = GetComponent<Collider2D>();

        if (itemId == 0)
        {
            //　出現規制フラグオン
            Debug.Log("GoldCatFlagオン");
            GameManager.Instance.GoldCatFlag = true;
        }
    }

    private void OnDisable()
    {
        if (itemId == 0)
        {
            GameManager.Instance.GoldCatFlag = false; // 出現ﾌﾗｸﾞオフ
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(thisObject.transform);

        if (thisObject.transform.childCount == 3)
        {
            ScoreManager.Instance.Score += thisScore;

            if (itemId == 0)
            {
                Debug.Log("GetGoldCatオン");
                GameManager.Instance.GetGoldCat = true;
                
            }
        }

        if(other.gameObject.tag == "Arrow")
        {
            Debug.Log("Collider無効化");
            myCollider.enabled = false;
        }
    }
}
