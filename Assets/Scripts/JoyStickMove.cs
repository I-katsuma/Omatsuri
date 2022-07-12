using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickMove : MonoBehaviour
{
    public GameObject joyStick; // スティック格納
    private RectTransform joystickRectTransform; // キャンバスポジション

    public GameObject backGrlound; // joyStickの後ろのやつ

    //public int stickRange = 3;

    //private int stickMovement = 0; // 実際に動く値


    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    public void Initialization()
    {
        // 違う画面サイズでも似たような挙動にするため
        //stickMovement = stickRange * (Screen.width + Screen.height) / 100;

        joystickRectTransform = joyStick.GetComponent<RectTransform>();

        // いったん非表示
        JoyStickDisplay(false);
    }

    private void JoyStickDisplay(bool x)
    {
        backGrlound.SetActive(x);
        joyStick.SetActive(x);
    }


    // 入力中に呼ぶ関数
    public void PointerDown(BaseEventData data)
    {
        PointerEventData pointer = data as PointerEventData;

        JoyStickDisplay(true);

        backGrlound.transform.position = pointer.position;
    }

    // 指を離した瞬間に呼ぶ関数
    public void PointerUp(BaseEventData data)
    {
        // JoyStickのPosition初期化関数を呼ぶ
        PositionInitialization();
    }

    // JoyStickのposition初期化
    public void PositionInitialization()
    {
        joystickRectTransform.anchoredPosition = Vector2.zero;
    }

}
