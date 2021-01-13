using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAccuracyController : MonoBehaviour
{
    private float m_TimeToNextHit = 5.0f;
    private float m_Timer;
    [SerializeField]
    private GameObject m_PlayerRef;
    private float m_ExtraOffsetMinX = 0.5f;
    private float m_ExtraOffsetMaxX = 2.0f;
    private float m_ExtraOffsetMinY = 0.2f;
    private float m_ExtraOffsetMaxY = 0.8f;
    private float m_PlayerHeightOffset;
    private float m_PlayerWidthOffset;


    void Update()
    {
        m_Timer += Time.deltaTime;
        CapsuleCollider playerCollider = m_PlayerRef.GetComponent<CapsuleCollider>();
        m_PlayerWidthOffset = playerCollider.radius;
        m_PlayerHeightOffset = playerCollider.height / 2.0f; //divide by two because we're aiming at the center of the player
    }

    public Vector3 FindBulletDirection(Vector3 bulletPos)
    {
        //direction will hit the player unless changed
        Vector3 playerPos = m_PlayerRef.transform.position;
        Vector3 direction = playerPos - bulletPos;
        if(m_Timer >= m_TimeToNextHit)
        {
            //allowed to hit the player, don't change direction
            m_Timer = 0.0f;
            CalculateTimeToNextHit();
        }
        else
        {
            //miss the player
            Vector3 fakePos = playerPos;
            float missOffsetZ = Random.Range(m_PlayerWidthOffset + m_ExtraOffsetMinX, m_PlayerWidthOffset + m_ExtraOffsetMaxX);
            //miss either to the left or right of the player
            if (Random.Range(0, 2) % 2 == 0)
            {
                missOffsetZ *= -1;
            }
            fakePos.z += missOffsetZ;
 
            float missOffsetY = Random.Range(m_PlayerHeightOffset + m_ExtraOffsetMinY, m_PlayerHeightOffset + m_ExtraOffsetMaxY);
            fakePos.y += missOffsetY;
            direction = fakePos - bulletPos;
        }


        return direction;
    }

    private void CalculateTimeToNextHit()
    {

    }
}
