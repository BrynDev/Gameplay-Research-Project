using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider m_Slider;

    public void SetHealth(int health)
    {
        m_Slider.value = health;
    }

    public void SetMaxHealth(int maxHealth)
    {
        m_Slider.maxValue = maxHealth;
        SetHealth(maxHealth);
    }
}
