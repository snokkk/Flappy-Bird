using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    public float pipeSpawnTime;
    public float pipeHeight;
    public float playerJumpForce;
    //public int bestScore = 0;
    public bool soundOn = true;
}
