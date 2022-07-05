using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResultProgress : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    SceneManagement sceneManagement;

    void Start()
    {
        GameManager.Instance.gameState = GameManager.GAME_STATE.RESULT;
    }

    // Update is called once per frame
    void Update()
    {
        var current = Keyboard.current;
        var spaceKey = current.spaceKey;

        if (spaceKey.isPressed)
        {
            sceneManagement.ResultToTitle();
        }
    }
}
