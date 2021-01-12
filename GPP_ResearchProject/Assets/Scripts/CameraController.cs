using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float m_MouseSensitivity = 500.0f;
    [SerializeField]
    private Transform m_PlayerTransform;

    private float m_RotationX = 0.0f;
    private float m_RotationY = 0.0f;
  
    void Start()
    {
        //hide cursor while in game
        Cursor.lockState = CursorLockMode.Locked;
    }
  
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity * Time.deltaTime;

        m_RotationX -= mouseY;
        m_RotationY += mouseX;
        //make sure camera can't flip vertically
        m_RotationX = Mathf.Clamp(m_RotationX, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(m_RotationX, m_RotationY, 0.0f);
        //Quaternion desiredRotation = Quaternion.Euler(m_RotationX, m_RotationY, 0.0f);
        //transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredRotation, Time.deltaTime);
        //rotate player transform according to camera
        m_PlayerTransform.Rotate(Vector3.up * mouseX);
        Quaternion startRotation = m_PlayerTransform.rotation;
        m_PlayerTransform.Rotate(Vector3.up * mouseX);
        Quaternion endRotation = m_PlayerTransform.rotation;
        m_PlayerTransform.rotation = Quaternion.Lerp(startRotation, endRotation, Time.deltaTime);
    }
}
