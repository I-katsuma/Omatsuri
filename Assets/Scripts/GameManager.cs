using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool windowPanelFlag = true; // ゲーム説明パネルのオンオフフラグ

    public bool arrowActive; // 矢が発射中だとtrue

    public bool touchPanelBool; // タッチパネルのオンオフ

    [Range(1f, 5f)]
    public float mainGameSpeed = 1f;

    public enum GAME_STATE
    {
        TITLE,
        PLAYING,
        GAMEOVER,
        RESULT,
        WAIT
    }
    public GAME_STATE gameState = GAME_STATE.TITLE;

    private void Awake() 
    {
        if(this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {
        arrowActive = false;
        Init();
    }

    public void Init()
    {
        gameState = GAME_STATE.TITLE;
        AudioManager.Instance.PlayBGM(BGMSoundData.BGM.PLAYING);
    }

    public void StateChange(int num)
    {
        switch (num)
        {
            case 0:
            gameState = GAME_STATE.TITLE;
            break;
            case 1:
            gameState = GAME_STATE.PLAYING;
            break;
            case 2:
            gameState = GAME_STATE.GAMEOVER;
            break;
            case 3:
            gameState = GAME_STATE.RESULT;
            break;

            case 4:  
            default:
            gameState = GAME_STATE.WAIT;
            break;
        }
    }

}
