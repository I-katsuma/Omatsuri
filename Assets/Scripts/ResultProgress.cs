using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResultProgress : MonoBehaviour
{
    //[SerializeField]
    //SceneManagement sceneManagement;
    public Text resultScoreText;

    public GameObject OMIGOTOtext;
    public GameObject GANBAtext;
    public GameObject APPAREtext;

    public Text nekoSerihu;

    public ResultSceneFade resultSceneFade;

    public Transform PrizeObjects; // ゲットした景品を並べる場所

    // PanelA(スコア)
    [SerializeField] GameObject ScorePanel;
    [SerializeField] GameObject ObjectPanel;
    [SerializeField] GameObject SerihuPanel;

    // PanelB(ランキング)
    [SerializeField] GameObject RankingPanel;

    // ボタン
    [SerializeField] GameObject ResultButton;
    [SerializeField] GameObject RankingButton;

    private bool rankingPanelFlag;

    void PanelA(bool x)
    {
        ScorePanel.SetActive(x);
        ObjectPanel.SetActive(x);
        SerihuPanel.SetActive(x);
        // ランキングに移行するため
        RankingButton.SetActive(x);
    }

    void PanelB(bool x)
    {
        RankingPanel.SetActive(x);
        ResultButton.SetActive(x);
    }

    public void RankingBoardButton()
    {
        PanelB(true);
        PanelA(false);
    }

    void Start()
    {

        PanelA(true);
        PanelB(false);

        GameManager.Instance.gameState = GameManager.GAME_STATE.RESULT;
        
        GameManager.Instance.GoldCatFlag = false;
        GameManager.Instance.GetGoldCat = false;

        resultScoreText.text = ScoreManager.Instance.Score.ToString("d3");

        if(ScoreManager.Instance.Score >= 900)
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.GOOD);
            APPAREtext.SetActive(true);
            nekoSerihu.text = "射的のてんさいにゃ";
        }
        else if(ScoreManager.Instance.Score >= 500)
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.GOOD);
            OMIGOTOtext.SetActive(true);
            nekoSerihu.text = "すごうでにゃん";
        }
        else
        {
            nekoSerihu.text = "おしいにゃんねぇ";
            GANBAtext.SetActive(true);
        }
    }

    void ObjectsClear()
    {
        if(PrizeObjects.transform.childCount > 0)
        {
            foreach(Transform c in PrizeObjects.transform)
            {
                GameObject.Destroy(c.gameObject);
            }
        }
    }


    public void ResultToTitle()
    {
        Debug.Log("ResultToTitle実行");
        ScoreManager.Instance.ScoreReset();
        ObjectsClear();

        SceneManager.LoadSceneAsync(0);
    }

    

    void Update()
    {
        var current = Keyboard.current;
        var spaceKey = current.spaceKey;

        if (spaceKey.wasPressedThisFrame)
        {
            if(!rankingPanelFlag)
            {
                RankingBoardButton();
                rankingPanelFlag = true;
            }
            else if(rankingPanelFlag)
            {
                ScoreManager.Instance.ScoreReset();
                ObjectsClear();
                resultSceneFade.ResultToTitle();                
                rankingPanelFlag = false;
            }

        }
    }
}
