using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject bestScorePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;


    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text gameOverScoreText;
    [SerializeField] private Text gameOverBestScoreText;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text settingsSoundText;

    [Inject]
    private GameController gameController;
    [Inject]
    private GameConfig gameConfig;
    [Inject]
    private ScoreManager scoreManager;
    [Inject]
    private SoundManager soundManager;
    [Inject]
    private TimeController timeController;

#if UNITY_EDITOR
    void OnValidate()
    {
        mainMenuPanel = transform.Find("pnl_MainMenu").gameObject;
        settingsPanel = transform.Find("pnl_Settings").gameObject;
        gamePanel = transform.Find("pnl_Game").gameObject;
        bestScorePanel = transform.Find("pnl_BestScore").gameObject;
        gameOverPanel = transform.Find("pnl_GameOver").gameObject;
        pausePanel = transform.Find("pnl_Pause").gameObject;
        bestScoreText = bestScorePanel.transform.Find("text_BestScore").GetComponent<Text>();
        gameOverScoreText = gameOverPanel.transform.Find("text_Score").GetComponent<Text>();
        gameOverBestScoreText = gameOverPanel.transform.Find("text_BestScore").GetComponent<Text>();
        currentScoreText = gamePanel.transform.Find("text_Score").GetComponent<Text>();
        settingsSoundText = settingsPanel.transform.Find("text_Sound").GetComponent<Text>();
    }
#endif

    public void Update()
    {
        ShowCurrentScore();
    }

    private void ShowCurrentScore()
    {
        currentScoreText.text = "" + scoreManager.score;
    }

    public void OnClickPLay()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameController.StartGame();
    }

    public void ChangeSoundText()
    {
        if (gameConfig.soundOn)
            settingsSoundText.text = "Sound ON";
        else
            settingsSoundText.text = "Sound OFF";
    }

    public void OnClickSettings()
    {
        ChangeSoundText();
        settingsPanel.SetActive(true);
    }

    public void OnClickBestScore()
    {
        bestScorePanel.SetActive(true);
        bestScoreText.text = "Best score: " + PlayerPrefs.GetInt("BestScore"); //gameConfig.bestScore;
    }

    public void OnClickClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ShowGameOverPnl()
    {
        gamePanel.SetActive(false);
        gameOverScoreText.text = "Score: " + scoreManager.score;
        gameOverBestScoreText.text = "Best score: " + PlayerPrefs.GetInt("BestScore"); //gameConfig.bestScore;
        gameOverPanel.SetActive(true);
    }

    public void OnClickRestart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OnClickContinue()
    {
        gameController.isPlaying = true;
        pausePanel.SetActive(false);
        timeController.StartTime();
    }

    public void OnClickPause()
    {
        gameController.isPlaying = false;
        pausePanel.SetActive(true);
        timeController.StopTime();
    }


    public void OnClickSound()
    {
        gameConfig.soundOn = !gameConfig.soundOn;
        ChangeSoundText();
        soundManager.SetSound();
    }

}
