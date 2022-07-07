using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutGimmick : MonoBehaviour
{
   public GameObject Panelfade;   //フェードパネルの取得

   Image fadealpha;               //フェードパネルのイメージ取得変数

   private float alpha;           //パネルのalpha値取得変数

   private bool fadeout;          //フェードアウトのフラグ変数

   //public int SceneNo;            //シーンの移動先ナンバー取得変数


   // Use this for initialization
   void Start()
   {
       fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
       alpha = fadealpha.color.a;                 //パネルのalpha値を取得
       //fadeout = true;                             //シーン読み込み時にフェードインさせる
   }

   // Update is called once per frame
   void Update()
   {

       if (fadeout == true)
       {
           FadeOut();
       }
   }

   public void FadeOutStart()
   {
        fadeout = true;
   }

   void FadeOut()
   {
    Debug.Log("実行");
       alpha += 0.01f;
       fadealpha.color = new Color(0, 0, 0, alpha);
       if (alpha >= 1)
       {
           fadeout = false;
       }
   }
}
