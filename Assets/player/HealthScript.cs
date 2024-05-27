using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 90;
    //public GameObject GameOverPanel;
 
    void Start()
    {
        healthBar.fillAmount = healthAmount / 100;
    }

    
    public void Damage(float DamageValue)
    {
        healthAmount -= DamageValue;     //инкремент и дискремент
        healthBar.fillAmount -= DamageValue/100;
    }
}
