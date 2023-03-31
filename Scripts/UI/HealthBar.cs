using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text tCurrentHealth;
    public Text tMaxHealth;
    public bool showText;

    public int lengthOfHealthNumber;
    
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        if (showText)
        {
            tMaxHealth.text = "/" + missingZeroes(maxHealth) +maxHealth.ToString();
            tCurrentHealth.text = missingZeroes(maxHealth) + maxHealth.ToString();
        }
        else
        {
            tMaxHealth.text = null;
            tCurrentHealth.text = null;
        }
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        if (showText) 
        {
            
            tCurrentHealth.text = missingZeroes(health) + health.ToString();
        }
        /*
        if(health < 10 && showText)
            tCurrentHealth.text = "0" + health.ToString();
        else if(showText)
            tCurrentHealth.text = health.ToString();
        */
    }

    string missingZeroes(int _health)
    {
        int numberOfMissingZeroes = lengthOfHealthNumber - _health.ToString().Length;
        string missingZeroes = null;
        for (int i = 0; i < numberOfMissingZeroes; i++)
            missingZeroes += "0";
        return missingZeroes;
    }
}
