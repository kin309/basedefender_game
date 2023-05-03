using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritualWolf : Monster
{
    [SerializeField] Character owner;

    public void SetOwner(Character _owner)
    {
        owner = _owner;
    }
    
    public void FollowOwner()
    {
        if (Vector2.Distance(transform.position, owner.transform.position) > 1.5f)
        {
            MoveTowardsDirection(owner.transform.position);
        }
        else
        {
            GetComponent<MovementController>().SetDirection(Vector2.zero);
        }
    }

    void Update()
    {
        FollowOwner();
    }
}
