using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;
    public GameObject reloadBar;

    private void Start()
    {
        slider.maxValue = 1f;
        slider.value = 1f;
    }
    public void StartReloadBar(float _reloadTime)
    {
        //reloadBar.alpha = 0f;
        slider.maxValue = _reloadTime;
        slider.value = 0;
    }

    public void UpdateReloadBar(float barChange)
    {
        slider.value += barChange;
            
    }

    
}
