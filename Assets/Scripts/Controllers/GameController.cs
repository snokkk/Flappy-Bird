using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject]
    private TimeController timeController;
    [Inject]
    private GameConfig gameConfig;
    [Inject]
    private ScoreManager scoreManager;
    [Inject]
    private UiController uiController;

    [SerializeField] private GameObject pipeSpawner;
    public bool isPlaying = false;

    void Start()
    {
        timeController.StopTime();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        timeController.StartTime();
        pipeSpawner.SetActive(true);
        isPlaying = true;
    }

    public void GameOver()
    {
        scoreManager.SetBestScore();
        uiController.ShowGameOverPnl();
        Time.timeScale = 0f;
        isPlaying = false;
    }
}
