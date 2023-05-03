using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    public static event Action<Entity> Died;
    [SerializeField] protected Stats stats;
    [SerializeReference] protected float currentHealth;
    protected bool alive = true;

    public virtual void TakeDamage(float value) {}

    public virtual void TakeDamage(float value, float duration, float force, Vector3 dir) {}

    public void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            alive = false;
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
