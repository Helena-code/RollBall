using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyLogic : MonoBehaviour
{
    // TODO ���� ���� ����� ���������� ���������� ��� ���� ����� �� ��������
    // ����� ������� ������ ����� � ���������
    // ��� ����� ��������

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.GetComponent<CurrentTypeOfBall>() != null)
            {
                GetComponentInParent<SimpleBallMove>().GoTo(other.gameObject);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            if (other.GetComponent<CurrentTypeOfBall>() != null)
            {
                GetComponentInParent<SimpleBallMove>().DoNotGo();
            }

        }
        
    }
}
