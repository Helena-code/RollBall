using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{

    public static GameUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameUIManager>();
                if (instance == null)
                {
                    instance = new GameUIManager();
                }
            }
            return instance;
        }

    }

    private static GameUIManager instance;

    public GameObject EndLevelPanel;
    public GameObject ScorePanel;
    public GameObject MainMenuPanel;
    public GameObject NextLevelButton;
    public Text CollectedText;
    public Text ScorePanelLevelText;
    public Text ScorePanelYellowText;
    public Text ScorePanelPinkText;

    private GameScoreManager gameScoreManager;
    // TODO переделать на единый номер уровня во всех скриптах
    int levelTemp = 1; 

    private void Awake()
    {
        EndLevelPanel.SetActive(false);
        ScorePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        NextLevelButton.SetActive(true);
        gameScoreManager = GetComponent<GameScoreManager>();
    }

    public void LoseLevel()
    {
        ShowEndLevelPanel();
    }

    public void WinLevel()
    {
        ShowEndLevelPanel();
        ShowWinElements();
    }

    public void StartButton()
    {
        SceneManager.LoadScene(levelTemp);

        MainMenuPanel.SetActive(false);
        ScorePanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void ContinueButton()
    {
        // TODO вызов последней не пройденной сцены
        // вызвать обновление данных по целям уровня
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        //levelTemp++;
        //SceneManager.LoadScene(levelTemp);

        //Time.timeScale = 1;
        // TODO вызвать обновление данных по целям уровня
    }

    public void RestartButton()
    {
        // вызвать обновление данных по целям уровня
    }

    public void ShowLevelInfo(int level, int goalYellow, int goalPink, int scoreYellow, int scorePink)
    {
        ScorePanelLevelText.text = "Level " + level;
        ScorePanelYellowText.text = scoreYellow + " / " + goalYellow;
        ScorePanelPinkText.text = scorePink + " / " + goalPink;
    }

    private void ShowEndLevelPanel()
    {
        RefreshCollectedText();
        EndLevelPanel.SetActive(true);
    }

    private void ShowWinElements()
    {
        NextLevelButton.SetActive(true);
    }

    private void RefreshCollectedText()
    {
        CollectedText.text = gameScoreManager.Score + " gums collected";
    }


}
