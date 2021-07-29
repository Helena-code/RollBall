using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.GetComponent<CurrentTypeOfBall>() != null)
            {
                switch (other.GetComponent<CurrentTypeOfBall>().typeOfBall)
                {
                    case (Types.typesOfBall.Yellow):
                        other.GetComponent<SimpleBallMove>().BecomeSticky();
                        Destroy(gameObject);
                        break;

                    case (Types.typesOfBall.Pink):
                        //other.GetComponent<StickyBallMove>().enabled = false;
                        other.GetComponent<SimpleBallMove>().enabled = false;
                        GameLogicManager.Instance.LoseLevel();
                        break;

                }
            }
        }
    }
}
