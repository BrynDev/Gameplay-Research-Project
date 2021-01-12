using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_MoveSpeed = 12.0f;

    private Rigidbody m_RigidBody;

    private void Awake()
    {
        m_RigidBody = gameObject.GetComponent<Rigidbody>();      
    }

    void FixedUpdate()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

       
        Vector3 movement = movementX * Camera.main.transform.right + movementZ * Camera.main.transform.forward;
        movement.y = 0.0f;
        movement.Normalize();
        movement *= m_MoveSpeed * Time.deltaTime;

        m_RigidBody.velocity = movement;
    }
}
