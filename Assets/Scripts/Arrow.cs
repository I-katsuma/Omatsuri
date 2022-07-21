using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    GameProgress gameProgress;

    //[SerializeField] Collider2D myCollider2D;
    [SerializeField]
    ScoreGetter scoreGetter;

    bool arrowHit;

    private void Start()
    {
        arrowHit = false;
        //myCollider2D = GetComponent<Collider2D>();
        scoreGetter = GameObject.Find("MainCanvas/ScorePanel").GetComponent<ScoreGetter>();
        gameProgress = GameObject.Find("GameProgress").GetComponent<GameProgress>();
    }


    public void HitColliderCheck(Collider2D collier)
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            this.transform.SetParent(other.gameObject.transform);
            Debug.Log("Hit!");

            arrowHit = true;

            AudioManager.Instance.PlaySE(SESoundData.SE.HIT);
            gameProgress.HitTextActive();

            int numID,
                numScore;
            numID = other.gameObject.GetComponent<ItemCollider>().itemId;
            numScore = other.gameObject.GetComponent<ItemCollider>().thisScore;
            scoreGetter.GetItemApper(numID, numScore);

            // ゲットした景品のIDとスコアをLISTに記憶
            ScoreManager.Instance.getIds.Add(other.gameObject.GetComponent<ItemCollider>().itemId);
            ScoreManager.Instance.getScores.Add(other.gameObject.GetComponent<ItemCollider>().thisScore);

        }
    }

    private void OnDisable()
    {
        arrowHit = false;
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
            if (arrowHit == false)
            {
                Debug.Log("Miss!");
                gameProgress.MissTextActive();
            }
            //GameManager.Instance.arrowActive = false;
            //Debug.Log("arrowActive:" + GameManager.Instance.arrowActive);
            Destroy(gameObject);
        }
    }
}
