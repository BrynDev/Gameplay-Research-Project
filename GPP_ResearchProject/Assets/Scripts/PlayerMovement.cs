using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController m_Controller;
    [SerializeField]
    private float m_MoveSpeed = 12.0f;

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * movementX + transform.forward * movementZ;
        movement.y = 0.0f;
        m_Controller.Move(movement * m_MoveSpeed * Time.deltaTime);
    }
}
