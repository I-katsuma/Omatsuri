using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameProgress : MonoBehaviour
{
    [SerializeField]
    GameObject InputCanvas;

    [SerializeField]
    GameObject HitTextObj;

    [SerializeField]
    GameObject MissTextObj;

    [SerializeField]
    ZankiManager zankiManager;

    [SerializeField]
    SceneManagement sceneManagement;

    [SerializeField]
    Transform getItems;

    [SerializeField]
    GameObject windowPanel;
    [SerializeField]
    GameObject nekoSerihu;

    bool touchBool;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.gameState = GameManager.GAME_STATE.WAIT;
        InputCanvas.SetActive(false);

        if (GameManager.Instance.windowPanelFlag == true) // 初回
        {
            windowPanel.SetActive(true);
            if(GameManager.Instance.touchPanelBool)
            {
                InputCanvas.SetActive(true);
            }
        }
        else // 二週目
        {
            windowPanel.SetActive(false);
            if(GameManager.Instance.touchPanelBool)
            {
                InputCanvas.SetActive(true);
            }
            else
            {
                InputCanvas.SetActive(false);
            }
            
            GameManager.Instance.gameState = GameManager.GAME_STATE.PLAYING;
        }
        HitTextObj.SetActive(false);
        MissTextObj.SetActive(false);
        nekoSerihu.SetActive(false);
        
    }


    public void WindowPanelClose()
    {
        AudioManager.Instance.PlaySE(SESoundData.SE.ENTER2);
        GameManager.Instance.windowPanelFlag = false;
        windowPanel.SetActive(false);
        if(GameManager.Instance.touchPanelBool)
        {
            InputCanvas.SetActive(true);
        }
        GameManager.Instance.gameState = GameManager.GAME_STATE.PLAYING;
    }

    /*
    IEnumerator Transparent()
    {
        for (int i = 0; i < 255; i++)
        {
            windowPanel.GetComponent<Image>();
        }
    }
    */

    private void Update()
    {
        if(GameManager.Instance.GetGoldCat)
        {
            nekoSerihu.SetActive(true);
        }

        var current = Keyboard.current;
        var spaceKey = current.spaceKey;

        if (windowPanel.activeSelf)
        {
            if (spaceKey.isPressed)
            {
                //AudioManager.Instance.PlaySE(SESoundData.SE.ENTER2);
                WindowPanelClose();
            }
        }
    }

    public void HitTextActive()
    {
        StartCoroutine("TextAction", true);
    }

    public void MissTextActive()
    {
        StartCoroutine("TextAction", false);
    }

    private IEnumerator TextAction(bool flag)
    {
        GameManager.Instance.gameState = GameManager.GAME_STATE.WAIT;
        if (flag == true) // HITなら
        {
            HitTextObj.SetActive(true);
            yield return new WaitForSeconds(3f);
            HitTextObj.SetActive(false);
        }
        else
        {
            MissTextObj.SetActive(true);
            yield return new WaitForSeconds(3f);
            MissTextObj.SetActive(false);
        }
        GameOverCheck();
    }

    void GameOverCheck()
    {
        if (GameManager.Instance.arrowActive == true)
        {
            GameManager.Instance.arrowActive = false;
            //Debug.Log("GameOverChack, arrowActive : " + GameManager.Instance.arrowActive);
        }

        //Debug.Log("GameOverCheck()");
        GameManager.Instance.gameState = GameManager.GAME_STATE.PLAYING;
        if (zankiManager.arrowNum == 0)
        {
            Debug.Log("Game終了、リザルト画面へ");
            //TODO 獲得した景品をリスト化、リザルトで並べて表示
            //if(GetChild(getItems.transform))
            //{Debug.Log("とれたよ");}
            if (getItems.transform.childCount > 0)
            {
                Debug.Log("0以上あるよ");
                GetChildTransform();
            }

            sceneManagement.GameToResult();
        }
    }

    void GetChildTransform()
    {
        foreach (Transform childTrandform in getItems.transform)
        {
            Debug.Log(childTrandform.gameObject.name);
        }
    }

    /*
    bool GetChild(Transform _transform)
    {
        if(_transform.childCount <= 0){return false;}

        for (int i = 0; i < getItems.childCount; i++)
        {
            ScoreManager.Instance.getItems.Add(
                _transform.GetChild(i).gameObject.transform
            );
            GetChild(_transform.GetChild(i));
        }
        return true;
    }
    */
}
