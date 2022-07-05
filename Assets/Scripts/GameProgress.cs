using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    [SerializeField]
    GameObject HitTextObj;

    [SerializeField]
    GameObject MissTextObj;

    [SerializeField]
    ZankiManager zankiManager;

    [SerializeField]
    SceneManagement sceneManagement;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.gameState = GameManager.GAME_STATE.PLAYING;
        HitTextObj.SetActive(false);
        MissTextObj.SetActive(false);
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
            Debug.Log("GameOverChack, arrowActive : " + GameManager.Instance.arrowActive);
        }

        //Debug.Log("GameOverCheck()");
        GameManager.Instance.gameState = GameManager.GAME_STATE.PLAYING;
        if (zankiManager.arrowNum == 0)
        {
            Debug.Log("Game終了、リザルト画面へ");
            sceneManagement.GameToResult();
        }
    }
}
