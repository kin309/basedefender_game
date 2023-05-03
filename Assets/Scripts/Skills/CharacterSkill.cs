using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : Skill<Character>
{
    public override IEnumerator Use(Character caster, Entity target) { yield return null; }

    public override IEnumerator Use(Character caster, List<Entity> targets) { yield return null; }
}
