using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhoneRotationRecorder
{
    static Vector3 accelPos;
    static bool firstStart;

    public static Vector3 accelPosStart
    {
        get
        {
            return accelPos;
        }

    }

    public static bool CheckStartPhonePosition()
    {
        // TODO � ������ ����� ������� �������� �� ������� �������� ��������, ��� ��������� ������� �������
        // ����� ��������� ����
        return firstStart;
    }

    public static IEnumerator SetStartAccelPosition()
    {
        // ��������� �������� ����� ��� ������� ����� 0, ������� ����� � 2 �������
        yield return new WaitForSeconds(2);
        accelPos = Input.acceleration;
       // Debug.Log("accelPosStart �� ������� " + accelPosStart);
        firstStart = true;

        //if (accelPos.x != 0 || accelPos.y != 0|| accelPos.y != 0)
        //{
        //    // TODO  ���������� ���������� ��������� ��������
        //    //������� �������� ����� �� ������� ���� �� ������ �������� xyz ��������� �� ����
        //    // ���� ���, ����� ������������� ����������
        //}


        
    }
}
