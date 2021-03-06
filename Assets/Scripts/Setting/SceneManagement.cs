using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    Fade fade;

    private void Start()
    {
        //Debug.Log("FadeOutStart");
        fade.FadeOut(1f);
    }

    public void TitleToGame()
    {
        fade.FadeIn(1f, () => SceneManager.LoadSceneAsync(1));
    }

    public void ButtonTitleToGame()
    {
        GameManager.Instance.touchPanelBool = true; 
        AudioManager.Instance.PlaySE(SESoundData.SE.ENTER);
        fade.FadeIn(1f, () => SceneManager.LoadSceneAsync(1));
    }

    public void GameToResult()
    {
        fade.FadeIn(1f, () => SceneManager.LoadSceneAsync(2));
    }

    
    public void ResultToTitle()
    {
        ScoreManager.Instance.ScoreReset();
        AudioManager.Instance.PlaySE(SESoundData.SE.ENTER);
        fade.FadeIn(1f, () => SceneManager.LoadSceneAsync(0));
    }
    
}
