using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject template;
    [SerializeField] private float secondBetweenSpawn;
    [SerializeField] private float maxSpawnPositionY;
    [SerializeField] private float minSpawnPositionY;

    private float elapsedTime = 0;

    private void Start()
    {
        Initialized(template);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondBetweenSpawn)
        {
            if (TryGetObject(out GameObject pipe))
            {
                elapsedTime = 0;

                var spawnPositionY = Random.Range(maxSpawnPositionY, minSpawnPositionY);
                var spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;
                
                DisableObjectAbroadScreen();
            }
        }
    }
}
