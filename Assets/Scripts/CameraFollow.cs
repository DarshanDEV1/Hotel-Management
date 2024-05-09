using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform m_Target_Object;
    [SerializeField] Vector3 m_Follow_Offset;
    [SerializeField] float m_Follow_Speed = 0.1f;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 targetPosition = m_Target_Object.position + m_Follow_Offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, m_Follow_Speed);
    }
}
