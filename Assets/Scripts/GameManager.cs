using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    public enum GAME_STATE
    {
        WAIT,
        PLAYING,
        GAMEOVER,
        RESULT,
    }


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
            
    }

    void Init()
    {

    }

}
