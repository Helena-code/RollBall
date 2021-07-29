using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.GetComponent<CurrentTypeOfBall>() != null)
            {
                Destroy(other.gameObject);
                GameLogicManager.Instance.LoseLevel();
            }
           
        }
    }
}
