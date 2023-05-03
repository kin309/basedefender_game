using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController<T> : MonoBehaviour
{
    [SerializeField] protected List<Skill<T>> skills = new List<Skill<T>>();
    
    private void Update() 
    {
        foreach (var sk in skills)
        {
            sk.Timer();
        }
    }

    public void UseSkill(int index, T caster, Entity target)
    {
        GetComponent<CharacterAnimator>().ChangeAnimationState(AnimationState.Char_Punch.ToString());
        if (skills[index].GetCurrentTime() <= 0)
        {
            StartCoroutine(skills[index].Use(caster, target));
            skills[index].SetCurrentTime();
        }
    }
}
