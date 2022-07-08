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

    public Text nekoSerihu;

    public GameObject Panelfade; //フェードパネルの取得

    Image fadealpha; //フェードパネルのイメージ取得変数

    private float alpha; //パネルのalpha値取得変数

    private bool fadeout; //フェードアウトのフラグ変数

    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a; //パネルのalpha値を取得

        GameManager.Instance.gameState = GameManager.GAME_STATE.RESULT;
        resultScoreText.text = ScoreManager.Instance.Score.ToString("d3");

        if(ScoreManager.Instance.Score >= 500)
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

    public void ResultToTitle()
    {
        Debug.Log("ResultToTitle実行");
        ScoreManager.Instance.ScoreReset();
        SceneManager.LoadSceneAsync(0);
    }

    void FadeOut()
    {
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            fadeout = false;

            OMIGOTOtext.SetActive(false);
            GANBAtext.SetActive(false);
            ResultToTitle();
        }
    }

    public void FadeOutStart()
    {
        fadeout = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout == true)
        {
            FadeOut();
        }

        var current = Keyboard.current;
        var spaceKey = current.spaceKey;

        if (spaceKey.isPressed)
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.ENTER);
            //ResultToTitle();
            FadeOutStart();
        }
    }
}
