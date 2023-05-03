using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterData : ScriptableObject
{
    public Stats stats;

    public List<Skill<Character>> skills = new List<Skill<Character>>();

    public abstract void Define();
}
