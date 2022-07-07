using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGetter : MonoBehaviour
{
    [SerializeField] Text scoreText;

    [SerializeField] Transform getItemPanel;

    [SerializeField] GameObject getItemPrefab;

    //設定する画像を用意
    [SerializeField] Sprite[] getItemsImageSprites;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text =  ScoreManager.Instance.Score.ToString("d3");
    }

    private void FixedUpdate() {
        scoreText.text =  ScoreManager.Instance.Score.ToString("d3");


    }

    public void GetItemApper(int numId, int numScore)
    {
        Debug.Log("ゲットした景品のIDは " + numId + "で、スコアは " + numScore + "です");
        GameObject getItem = Instantiate(getItemPrefab);
        getItem.GetComponent<Image>().sprite = getItemsImageSprites[numId];
        getItem.GetComponent<GetItem>().thisScoreText.text = numScore.ToString();
        getItem.transform.SetParent(getItemPanel);
    } 


}
