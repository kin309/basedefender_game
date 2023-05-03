using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatInfo
{
    public CharacterStat type;
    public float value;
}

public enum CharacterStat
{
    health,
    damage,
    attackSpeed,
    moveSpeed,
    range,
    manaPool,
    mana,
    manaRecovery,
    manaPoolRecovery,
}