using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill<T>
{
    protected float cost;
    protected float cooldown;
    protected float currentTime;

    public abstract IEnumerator Use(T caster, Entity target);

    public abstract IEnumerator Use(T caster, List<Entity> targets);

    public void Timer()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (currentTime < 0)
        {
            currentTime = 0;
        }
    }

    public void SetCurrentTime()
    {
        currentTime = cooldown;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
