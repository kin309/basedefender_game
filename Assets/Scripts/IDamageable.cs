using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(float value);

    public void TakeDamage(float value, float duration, float force, Vector3 dir);
}

public enum HurtboxType
{
    Player = 1 << 0,
    Enemy = 1 << 1,
    Ally = 1 << 2
}

public enum HurtboxMask
{
    None = 0,
    Player = 1 << 0,
    Enemy = 1 << 1,
    Ally = 1 << 2
}