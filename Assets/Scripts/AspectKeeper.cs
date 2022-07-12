using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AspectKeeper : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;

    [SerializeField] Vector2 aspectVec; // 目的解消度


    void Update()
    {
        var screenAspect = Screen.width / (float) Screen.height; // 画面のアスペクト比
        var targetAspect = aspectVec.x / aspectVec.y; // 目的アスペクト比

        var magRate = targetAspect / screenAspect; // 目的アスペクト比にするための倍率

        var viewPortrect = new Rect(0, 0, 1, 1); //
        viewPortrect.width = magRate;
        targetCamera.rect = viewPortrect;

        if(magRate < 1)
        {
            viewPortrect.width = magRate; // 使用する横幅を変更
            viewPortrect.x = 0.5f - viewPortrect.width * 0.5f; // 中央寄せ
        }
        else
        {
            viewPortrect.height = 1 / magRate; // 使用する縦幅を変更
            viewPortrect.y = 0.5f - viewPortrect.height * 0.5f; // 中央寄せ
        }

        targetCamera.rect = viewPortrect; // カメラのViewportに適用
    }
}
