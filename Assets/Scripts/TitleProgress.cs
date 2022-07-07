using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleProgress : MonoBehaviour
{
    [SerializeField] SceneManagement sceneManagement;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.Score = 0;
        GameManager.Instance.gameState = GameManager.GAME_STATE.TITLE;
    }

    private void Update()
    {
        var current = Keyboard.current;
        var spaceKey = current.spaceKey;

        if(spaceKey.isPressed)
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.ENTER);
            sceneManagement.TitleToGame();
        }
    }
}
