using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Monster
{
    void Update()
    {
        Chase();
    }

    public void Chase()
    {
        MoveTowardsDirection(target.transform.position);
    }
}
