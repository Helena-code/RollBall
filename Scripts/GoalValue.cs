using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalValue : MonoBehaviour
{
    [Header("Set Level Goals: X-yellow, Y-pink")]

    public Vector2[] LevelsValue;
    //public Vector2 level1;
    //public Vector2 level2;
    //public Vector2 level3;
    //public Vector2 level4;
    //public Vector2 level5;
    //public Vector2 level6;
    //public Vector2 level7;
    //public Vector2 level8;
    //public Vector2 level9;
    //public Vector2 level10;

    public void SetGoals()
    {

    }
    
    public Vector2 GetGoals(int level)
    {
        return LevelsValue[level];
    }

    //public Vector2 GetGoals(GameScoreManager.Levels level)
    //{
    //    switch (level)
    //    {
    //        case GameScoreManager.Levels.L0:
    //            return LevelsValue[0];

    //        case GameScoreManager.Levels.L1:
    //            return LevelsValue[1];

    //    }
    //}
}
