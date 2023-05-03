using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Entity, IDamageable
{
    protected Rigidbody2D rb;
    [SerializeField] protected float multiplier = 1;
    protected MovementController movementController;
    protected ProgressBar healthBar;


    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        alive = true;
        currentHealth = stats.GetStat(CharacterStat.health);
        movementController = GetComponent<MovementController>();
        healthBar = GetComponentInChildren<ProgressBar>();
    }

    public virtual void Start()
    {
        healthBar.Set(currentHealth, currentHealth);
    }

    public override void TakeDamage(float value)
    {
        if (alive)
        {
            ModifyHealth(-value*multiplier);
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
        var moveControll = GetComponent<MovementController>();
        moveControll.Knock(duration, force, dir);
    }

    public void ModifyHealth(float value)
    {
        currentHealth += value;
        healthBar.SetFill(currentHealth);

    }

    public void IncreaseDamageTaken(float value)
    {
        multiplier += value;
    }
}
