using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderControl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] PlayerControl playerControl;

    [SerializeField] Slider shotPowerSlider;
    private bool _Push;
    
    // Start is called before the first frame update
    void Start()
    {
        float maxPower = 120f;
        //float nowPower = 0f;

        shotPowerSlider.maxValue = maxPower;
        //shotPowerSlider.value = nowPower;
        shotPowerSlider.value = playerControl.shotPower;
    }

    public void SliderMethod()
    {
        if(shotPowerSlider.value >= 100)
        {
            Debug.Log("100以上です");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown:押した");
        _Push = true;
        playerControl.kamaeAnimMethod(true);
        //playerControl.shotPower += 1.2f;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp:押下状態から離した");
        _Push = false;
        playerControl.kamaeAnimMethod(false);
        playerControl.shotPower = shotPowerSlider.value;
        if(shotPowerSlider.value >= 100f)
        {    
            playerControl.ArrowShotMethod();
        }
    }


    void Update()
    {
        shotPowerSlider.value --;
        if(_Push == false)
        {
            shotPowerSlider.value -= 20f;    
        }
    }

    
}
