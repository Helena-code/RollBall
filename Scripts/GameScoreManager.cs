using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreManager : MonoBehaviour
{

    public static GameScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameScoreManager>();
                if (instance == null)
                {
                    instance = new GameScoreManager();
                }
            }
            return instance;
        }

    }

    public enum Levels
    {
        L0,
        L1,
        L2,
        L3,

    }



    public int Score
    {
        get
        {
            return scoreTotal;
        }
    }


    private static GameScoreManager instance;
    private  GameUIManager gameUIManager;
    private GoalValue goalsValueScript;
    // private Levels currentLevel;
    private int currentLevel;
    private int scoreTotal;
    private int scoreYellow;
    private int scorePink;
    private int goalLevelTotal;
    private int goalLevelYellow;
    private int goalLevelPink;


    private void Awake()
    {
        gameUIManager = GetComponent<GameUIManager>();
        scoreTotal = 0;
        scoreYellow = 0;
        scorePink = 0;
        goalLevelTotal = 0;
        goalLevelYellow = 0;
        goalLevelPink = 0;
        currentLevel = 0;
        // currentLevel = Levels.L0;
        //Vector2 v=  GetComponent<GoalValue>().GetGoals(currentLevel);
        goalsValueScript = GetComponent<GoalValue>();
        GetGoalOfLevel();
    }

    public void AddScore(Types.typesOfBall type)
    {
        switch (type)
        {
            case Types.typesOfBall.Yellow:
                scoreYellow++;
                break;
            case Types.typesOfBall.Pink:
                scorePink++;
                break;
        }
        scoreTotal = scoreYellow + scorePink;
        gameUIManager.ShowLevelInfo(currentLevel, goalLevelYellow, goalLevelPink, scoreYellow, scorePink);
        CheckTheWin();
    }

    private void CheckTheWin()
    {
        if ((goalLevelYellow== scoreYellow)&& (goalLevelPink == scorePink))
        {
            GameLogicManager.Instance.WinLevel();
        }
    }

    private void GetGoalOfLevel()
    {
        goalLevelYellow = (int)goalsValueScript.GetGoals(currentLevel).x;
        goalLevelPink = (int)goalsValueScript.GetGoals(currentLevel).y;
        goalLevelTotal = goalLevelYellow + goalLevelPink;

        gameUIManager.ShowLevelInfo(currentLevel, goalLevelYellow, goalLevelPink, scoreYellow, scorePink);
    }
}
