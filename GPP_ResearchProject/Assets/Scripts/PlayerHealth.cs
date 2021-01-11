using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
    public int m_MaxHealth;
    private int m_CurrentHealth;
    public HealthBar m_HealthBar;

    void Start()
    {
        m_CurrentHealth = m_MaxHealth;
        m_HealthBar.SetMaxHealth(m_MaxHealth);
    }

    public void TakeDamage(int damage)
    {
        m_CurrentHealth -= damage;
        m_HealthBar.SetHealth(m_CurrentHealth);
    }
}
