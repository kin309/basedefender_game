using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] Creature target;
    [SerializeField] float damage;

    void Start()
    {
        InvokeRepeating("Shoot", 1, 1);
    }

    void Update()
    {
    }

    public void Shoot()
    {
        var newProjectile = Instantiate(projectile);
        newProjectile.transform.position = transform.position;
        newProjectile.Define(target.transform.position - transform.position, damage);
    }
}
