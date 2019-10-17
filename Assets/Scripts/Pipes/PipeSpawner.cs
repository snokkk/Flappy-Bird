using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PipeSpawner : MonoBehaviour
{

    [Inject]
    private GameConfig gameConfig;

    [SerializeField] private float spawnTime;
    [SerializeField] private float height;
    private float timer;

    [SerializeField] private GameObject pipe;

    private void Awake()
    {
        spawnTime = gameConfig.pipeSpawnTime;
        height = gameConfig.pipeHeight;
    }

    void Start()
    {
        PipeInstantiate();
    }

    void Update()
    {
        if (timer > spawnTime)
        {
            PipeInstantiate();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void PipeInstantiate()
    {
        GameObject newPipe = Instantiate(pipe);
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

}
