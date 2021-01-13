using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Gun m_Gun;
    [SerializeField]
    private GameObject m_PlayerRef;
    [SerializeField]
    private float m_MaxDetectionRange = 0.0f;
    private bool m_HasDetectedPlayer = false;

    private void Awake()
    {
        //m_Gun = gameObject.GetComponent<Gun>();
        m_Gun = gameObject.GetComponentInChildren<Gun>();
    }

    static string[] RAYCAST_MASK = new string[] { "Player" };
    private void FixedUpdate()
    {
       m_Gun.SetCanShoot(m_HasDetectedPlayer);
       if(m_HasDetectedPlayer)
       {
            transform.LookAt(m_PlayerRef.transform);
       }

       DetectPlayer();
    }

    private void DetectPlayer()
    {
        Vector3 rayDirection = (m_PlayerRef.transform.position - transform.position);
        Ray ray = new Ray(transform.position, rayDirection);
        m_HasDetectedPlayer = Physics.Raycast(ray, m_MaxDetectionRange, LayerMask.GetMask(RAYCAST_MASK));       
    }
}
