using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] GameProgress gameProgress;

    private void Start()
    {
        gameProgress = GameObject.Find("GameProgress").GetComponent<GameProgress>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            this.transform.SetParent(other.gameObject.transform);
            Debug.Log("Hit!");
            gameProgress.HitTextActive();
            ScoreManager.Instance.getItems.Add(other.gameObject);
            //flagChange();
        }
    }


/*
    void flagChange() // 矢が景品に当たったら発射フラグチェンジ
    {
        if (GameManager.Instance.arrowActive == true)
        {
            GameManager.Instance.arrowActive = false;
            Debug.Log("Arrow.cs, flagChange() : " + GameManager.Instance.arrowActive);
        }
    }
*/

    void Update()
    {
        if (this.transform.position.y > 5.55f) // 矢がミスった場合
        {
            Debug.Log("Miss!");
            gameProgress.MissTextActive();
            //GameManager.Instance.arrowActive = false;
            //Debug.Log("arrowActive:" + GameManager.Instance.arrowActive);
            Destroy(gameObject);
        }
    }
}
