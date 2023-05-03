using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : Structure
{
    [SerializeField] List<Character> allies;
    [SerializeField] float attackRange;
    [SerializeField] float auraRange;
    [SerializeField] Projectile projectile;
    [SerializeField] float damage;
    [SerializeField] float attackSpeed;

    
    void FixedUpdate()
    {
        ApplyAura();
    }

    void ApplyAura()
    {
        foreach(var ally in allies)
        {
            float distance = (ally.transform.position - transform.position).sqrMagnitude;
            if (distance > auraRange)
            {
                ally.OutOfAuraDebuff();
            }
            else
            {
                ally.BackToAura();
            }
        }
    }

    public void HitAllMonstersInRange(Monster[] monsters)
    {
        Shoot(Targets.GetClosestEntityInRange(transform, monsters, attackRange));
    }

    public void Shoot(Entity target)
    {
        if (target != null)
        {
            var newProjectile = Instantiate(projectile);
            newProjectile.transform.position = transform.position;
            newProjectile.Define(target.transform.position - transform.position, damage);
        }
        
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
}
