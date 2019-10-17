using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    [Inject]
    private GameConfig gameConfig;

    public int score = 0;

    public void GetScore()
    {
        score++;
    }

    public void SetBestScore()
    {
        if (score > gameConfig.bestScore)
            gameConfig.bestScore = score;
    }
}
