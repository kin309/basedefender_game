using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Creature
{
    CharacterAnimator characterAnimator;
    CharacterSkillController characterSkillController;
    [SerializeField] CharacterData data;
    [SerializeField] float outOfAuraResistTime;
    float currentTimeOutOfAura;
    bool debufApplied = false;
    new CharacterMovementController movementController;
    [SerializeField] public GameObject novaParticle;
    [SerializeField] LayerMask enemyLayer;
    public bool attacking;


    public override void Awake() {
        base.Awake();
        movementController = GetComponent<CharacterMovementController>();
        characterSkillController = GetComponent<CharacterSkillController>();
        characterAnimator = GetComponent<CharacterAnimator>();
        data.Define();
    }

    public override void Start() {
        base.Start();
        characterSkillController.SetSkills(data.skills);
    }

    private void Update() {
        movementController.ProcessInputs(attacking);
        Inputs();

        Animation();
    }

    public void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
            else if (Input.GetMouseButtonDown(1))
            {

            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            characterSkillController.UseSkill(0, this, null);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            movementController.Dash(movementController.GetDirection());
        }
    }

    public void CheckForEnemies(float duration, float force)
    {
        List<Collider2D> colliders = new List<Collider2D>();
        Collider2D col = novaParticle.GetComponent<CapsuleCollider2D>();
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        col.OverlapCollider(filter, colliders);

        foreach(Collider2D c in colliders)
        {
            if (c.gameObject.layer == 3)
            {
                c.GetComponent<Entity>().TakeDamage(stats.GetStat(CharacterStat.damage), duration, force, -(transform.position - c.transform.position).normalized);
            }
        }
    }

    public void OutOfAuraDebuff()
    {
        currentTimeOutOfAura += Time.deltaTime;
        
        if (debufApplied == false && outOfAuraResistTime < currentTimeOutOfAura)
        {
            IncreaseDamageTaken(0.1f);
            movementController.SetSpeed(movementController.GetSpeed()*0.5f);
            debufApplied = true;
        }
    }

    public void BackToAura()
    {
        currentTimeOutOfAura = 0;
        if (debufApplied == true)
        {
            IncreaseDamageTaken(-0.1f);
            movementController.SetSpeed(movementController.GetSpeed()/0.5f);
            debufApplied = false;
        }
    }

    public void Animation()
    {
        if (movementController.GetDirection() == Vector2.zero && characterAnimator.GetCurrentAnimation() != AnimationState.Char_Punch.ToString())
        {
            characterAnimator.ChangeAnimationState(AnimationState.Char_Idle.ToString());
        }
        else if (characterAnimator.GetCurrentAnimation() != AnimationState.Char_Punch.ToString())
            {
                if (movementController.GetMovementDirection() < 0 && !attacking)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (movementController.GetMovementDirection() > 0 && !attacking)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                characterAnimator.ChangeAnimationState(AnimationState.Char_Walk.ToString());
            }
    }
}
