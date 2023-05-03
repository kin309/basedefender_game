using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : Entity, IDamageable
{
    public override void TakeDamage(float value)
    {
        if (alive)
        {
            ModifyHealth(-value);
            CheckDeath();
        }
    }
    public override void TakeDamage(float value, float duration, float force, Vector3 dir)
    {
        if (alive)
        {
            ModifyHealth(-value);
            CheckDeath();
        }
    }

    public void ModifyHealth(float value)
    {
        currentHealth += value;
    }
}
