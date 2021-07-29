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
        // TODO в методе старт сделать проверку на возврат булевого значения, что положение считано успешно
        // можно запускать игру
        return firstStart;
    }

    public static IEnumerator SetStartAccelPosition()
    {
        // положение телефона сразу при запуске будет 0, поэтому пауза в 2 секунды
        yield return new WaitForSeconds(2);
        accelPos = Input.acceleration;
       // Debug.Log("accelPosStart из статики " + accelPosStart);
        firstStart = true;

        //if (accelPos.x != 0 || accelPos.y != 0|| accelPos.y != 0)
        //{
        //    // TODO  считывание стартового положения телефона
        //    //сделать проверку потом на наличие хотя бы одного значения xyz отличного от нуля
        //    // если нет, тогда перезапустить энумератор
        //}


        
    }
}
