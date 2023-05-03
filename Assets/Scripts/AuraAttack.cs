using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraAttack : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] Monster[] enemies;
    [SerializeField] float cooldown;
    float currentTime;
    Creature creature;

    void Awake()
    {
        creature = GetComponent<Creature>();
    }

    void Update()
    {
        if (currentTime <= 0)
        {
            HitAllMonstersInRange(enemies);
            currentTime = cooldown;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    public void HitClosestMonster(Monster[] monsters)
    {
        var target = Targets.GetClosestMonsterInRange(transform, monsters, range);
        if (target == null)
            return;
    }

    public void HitAllMonstersInRange(Monster[] monsters)
    {        
        foreach(var monster in Targets.GetAllMonstersInRange(transform, monsters, range))
        {
        }
    }
}
