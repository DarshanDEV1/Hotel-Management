using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Joystick m_Joystick;
    [SerializeField] CharacterController m_Controller;
    [SerializeField] Transform m_Controls;
    [SerializeField] Transform m_PlayerCamera;
    [SerializeField] float m_MovementSpeed;
    [SerializeField] float m_RotationSpeed;

    private void Start()
    {
        m_PlayerCamera.transform.SetParent(FindObjectOfType<GameManager>().transform);
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float x = m_Joystick.Horizontal;
        float z = m_Joystick.Vertical;

        if (x != 0 || z != 0)
        {
            Vector3 m_Movement = transform.right * x + transform.forward * z;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, GetRotation(-x, z) - 90, 0), m_RotationSpeed * Time.deltaTime);
            m_Controller.Move(transform.forward * m_MovementSpeed * Time.deltaTime);
        }
    }

    private float GetRotation(float x, float z)
    {
        float m_Rot = Mathf.Atan2(z, x);
        return m_Rot * Mathf.Rad2Deg;
    }
}
