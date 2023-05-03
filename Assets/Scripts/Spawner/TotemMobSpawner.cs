using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class TotemMobSpawner : Spawner
{
    public static event Action<Monster> MobSpawned;

    private void Start() {
        Spawn();
    }

    protected void Spawn()
    {
        StartCoroutine(SpawnCoroutine(spawnRate, true));
    }

    protected IEnumerator SpawnCoroutine(float time, bool loop)
    {
        float randSpawnDistance = Random.Range(spawnMinDistance, spawnMaxDistance);
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * randSpawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;
            var monster = Instantiate(monstersPrefab[0], spawnPoint, Quaternion.identity);
            MobSpawned?.Invoke((Monster)monster);
        }
        yield return new WaitForSeconds(time);
        if (loop)
            StartCoroutine(SpawnCoroutine(time, loop));
    }
}
