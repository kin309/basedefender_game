using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Stark")]
public class Stark : CharacterData
{
    public override void Define() {
        skills.Add(new Punch(1/stats.GetStat(CharacterStat.attackSpeed)));
    }
}
