using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int m_MaxHealth = 100;
    private int m_CurrentHealth;
    private bool m_IsHealing = false;
    public const float m_HealStartDelay = 2.0f;
    private float m_HealStartDelayTimer = 0.0f;
    public const float m_HealTickDelay = 0.5f;
    private float m_HealTickTimer = 0.0f;
    public const int m_HealthRestorePerTick = 2;

    public HealthBar m_HealthBar;

    void Start()
    {
        m_CurrentHealth = m_MaxHealth;
        m_HealthBar.SetMaxHealth(m_MaxHealth);
    }

    public void TakeDamage(int damage)
    {
        m_CurrentHealth -= damage;
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0, m_MaxHealth);
        m_HealthBar.SetHealth(m_CurrentHealth);
        m_IsHealing = false;
    }

    public void RestoreHealth(int health)
    {
        m_CurrentHealth += health;
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0, m_MaxHealth);
        m_HealthBar.SetHealth(m_CurrentHealth);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (!m_IsHealing)
        {
            m_HealStartDelayTimer += Time.deltaTime;

            if (m_HealStartDelayTimer >= m_HealStartDelay)
            {
                //once timer has expired, start healing and reset timer
                m_IsHealing = true;
                m_HealStartDelayTimer = 0.0f;
            }
        }
        else
        {
            m_HealTickTimer += Time.deltaTime;
            if (m_HealTickTimer >= m_HealTickDelay)
            {
                RestoreHealth(m_HealthRestorePerTick);
                m_HealTickTimer = 0.0f;
            }
        }

    }
}
