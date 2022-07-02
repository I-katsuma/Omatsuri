using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    [SerializeField] Fade fade;

    private void Start() {
        fade.FadeOut(1f);
    }

    public void TitleToGame()
    {
        fade.FadeIn(1f, () => SceneManager.LoadSceneAsync(1));
    }   

    public void GameToResult()
    {
        fade.FadeIn(1f, () => SceneManager.LoadSceneAsync(2));
    } 

    public void ResultToTitle()
    {
        ScoreManager.Instance.ScoreReset();
        fade.FadeIn(1f, () => SceneManager.LoadSceneAsync(0));
    }
}
