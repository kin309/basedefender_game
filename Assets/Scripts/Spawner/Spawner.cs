using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected float spawnRate;
    [SerializeField] protected float spawnMinDistance;
    [SerializeField] protected float spawnMaxDistance;
    [SerializeField] protected int spawnAmount;
    [SerializeField] protected List<Entity> monstersPrefab;
}
