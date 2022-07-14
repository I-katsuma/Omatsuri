using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneFade : MonoBehaviour
{
    [SerializeField] Fade fade;

    public void ResultToTitle()
    {
        ScoreManager.Instance.ScoreReset();
        AudioManager.Instance.PlaySE(SESoundData.SE.ENTER);
        fade.FadeIn(1f, () => SceneManager.LoadSceneAsync(0));
    }
}
