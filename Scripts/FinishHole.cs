using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHole : MonoBehaviour
{
    public Types.typesOfBall type;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.GetComponent<CurrentTypeOfBall>() != null)
            {
                type = other.gameObject.GetComponent<CurrentTypeOfBall>().typeOfBall;
                GameLogicManager.Instance.CheckScore(type);
                Destroy(other.gameObject);
            }
        }
    }
}
