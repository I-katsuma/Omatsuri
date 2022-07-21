using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPriseApper : MonoBehaviour
{
    [SerializeField] GameObject prisePrefab;
    [SerializeField] Sprite[] prizeSprites;

    void Start()
    {
        int listCount = ScoreManager.Instance.getIds.Count;
        //var pos = this.transform;
        for (int i = 0; i < listCount; i++)
        {
            //Debug.Log(ScoreManager.Instance.getIds[i]);
            int listNum = ScoreManager.Instance.getIds[i];
            int prizeScore = ScoreManager.Instance.getScores[i];

            GameObject obj = Instantiate(prisePrefab, this.transform.position, Quaternion.identity);
            obj.GetComponent<Image>().sprite = prizeSprites[listNum];
            obj.GetComponent<prizeState>().scoreText.text = prizeScore.ToString();
            obj.transform.SetParent(this.transform);
        }
    }

    
}
