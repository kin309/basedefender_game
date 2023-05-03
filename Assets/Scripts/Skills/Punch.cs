using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : CharacterSkill
{
    public Punch(float _cooldown)
    {
        cooldown = _cooldown;
    }
    
    public override IEnumerator Use(Character caster, Entity target)
    {
        yield return new WaitForSeconds(0.05f);
        caster.attacking = true;
        if (Input.mousePosition.x/100 - 10 < 0)
        {
            caster.transform.localScale = caster.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.mousePosition.x/100 - 10 > 0)
        {
            caster.transform.localScale = caster.transform.localScale = new Vector3(1, 1, 1);
        }
        caster.novaParticle.SetActive(true);
        caster.CheckForEnemies(0.1f, 12);
        yield return new WaitForSeconds(0.3f);
        caster.attacking = false;
        caster.novaParticle.SetActive(false);
    }
}
