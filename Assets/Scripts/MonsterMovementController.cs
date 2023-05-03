using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovementController : MovementController
{
    public override void SetDirection(Vector2 dir)
    {
        base.SetDirection(dir);
        if (dir.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (dir.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
