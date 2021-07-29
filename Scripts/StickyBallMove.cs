using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBallMove : MonoBehaviour
{
    [Range(10f, 1000f)]
    public float speed;

    Rigidbody rb;
    Vector3 accelPosition;
    Vector3 movePosition;

    // TODO - ���� ������������ ����� �� ���������
    // ����� ������� �������� ���� ������ ��������
    // � ���� ��������� ����� ������ � ������

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movePosition = Vector3.zero;
        movePosition.y = transform.position.y;
    }
    private void Update()
    {
        accelPosition = Input.acceleration;

        
        movePosition.x = accelPosition.x;
        movePosition.z = accelPosition.y;

        if (movePosition.sqrMagnitude > 1)
        {
            movePosition.Normalize();
        }
        
       

    }
    private void FixedUpdate()
    {
        movePosition *= Time.fixedDeltaTime;
        rb.velocity = movePosition * (speed*0.8f);
    }
}
