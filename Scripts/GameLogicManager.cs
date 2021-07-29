using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    public static GameLogicManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameLogicManager>();
                if (instance == null)
                {
                    instance = new GameLogicManager();
                }
            }
            return instance;
        }

    }

    private static GameLogicManager instance;

    private GameUIManager gameUIManager;
    private GameScoreManager gameScoreManager;


    private void Awake()
    {
        gameUIManager = GetComponent<GameUIManager>();
        gameScoreManager = GetComponent<GameScoreManager>();
        //GetComponent<GoalValue>().
        StartCoroutine(PhoneRotationRecorder.SetStartAccelPosition());
    }

    public void LoseLevel()
    {
        Time.timeScale = 0;
        GameUIManager.Instance.LoseLevel();
    }

    public void WinLevel()
    {
        Time.timeScale = 0;
        GameUIManager.Instance.WinLevel();
    }

    public void CheckScore(Types.typesOfBall type)
    {
        gameScoreManager.AddScore(type);
    }

   
}
