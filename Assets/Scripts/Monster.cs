using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Creature
{
    [SerializeField] protected Entity target;

    public void MoveBackwardsDirection(Vector3 dir)
    {
        rb.velocity = stats.GetStat(CharacterStat.moveSpeed)*(transform.position - dir).normalized;
    }

    public void MoveTowardsDirection(Vector3 dir)
    {
        GetComponent<MonsterMovementController>().SetDirection(-1*(transform.position - dir).normalized);
    }
    public void SetTarget(Entity _target)
    {
        target = _target;
    }
}
