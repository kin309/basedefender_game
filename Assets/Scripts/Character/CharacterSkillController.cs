using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkillController : SkillController<Character>
{
    public void SetSkills(List<Skill<Character>> _skills)
    {
        skills = _skills;
    }
}
