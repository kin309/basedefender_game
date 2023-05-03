using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] Fountain fountain;
    [SerializeField] Entity monstersTarget;
    [SerializeField] List<Monster> monsters = new List<Monster>();

    void Awake()
    {
        MobSpawner.MobSpawned += OnMobSpawned;
        Monster.Died += OnMonsterDied;
    }
    
    void Start()
    {
        StartCoroutine(FountainAttack());
        foreach (var mon in monsters)
        {
            mon.SetTarget(monstersTarget);
        }
    }

    void OnMobSpawned(Monster monster)
    {
        monsters.Add(monster);
        monster.SetTarget(monstersTarget);
    }

    IEnumerator FountainAttack()
    {
        fountain.HitAllMonstersInRange(monsters.ToArray());
        yield return new WaitForSeconds(1/fountain.GetAttackSpeed());
        StartCoroutine(FountainAttack());
    }

    void OnMonsterDied(Entity monster)
    {
        if (monster is Monster)
        {
            monsters.Remove((Monster)monster);
        }
    }
}
