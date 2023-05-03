using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Targets
{
    public static Monster GetClosestMonster (Transform transform, Monster[] monsters)
    {
        Monster bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(var potentialTarget in monsters)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    public static Monster GetClosestMonsterInRange (Transform transform, Monster[] monsters, float range)
    {
        Monster bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(var potentialTarget in monsters)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        if (closestDistanceSqr < range)
            return bestTarget;
        
        return null;
    }

    public static List<Monster> GetAllMonstersInRange(Transform transform, Monster[] _monsters, float range)
    {
        List<Monster> monsters = new List<Monster>();
        foreach (var monster in new List<Monster>(_monsters))
        {
            if ((monster.transform.position - transform.position).sqrMagnitude < range)
            {
                monsters.Add(monster);
            }
        }

        return monsters;
    }

    public static Entity GetClosestEntityInRange (Transform transform, Entity[] entities, float range)
    {
        Entity bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(var potentialTarget in entities)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        if (closestDistanceSqr < range)
            return bestTarget;
        
        return null;
    }
}
