using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeReference] float activeSpeed;
    [SerializeReference] float speed;
    [SerializeReference] protected float dashDuration = 0.3f;
    [SerializeReference] protected float dashSpeed = 10f;
    float currentDashTime;
    float currentKnockTime;
    protected Vector2 moveDirection;
    Rigidbody2D rb;
    protected bool dashing;
    protected bool knocking;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        activeSpeed = speed;
    }

    private void Update() 
    {
        if (currentDashTime > 0)
        {
            currentDashTime -= Time.deltaTime;
        }
        else if (dashing)
        {
            dashing = false;
            currentDashTime = 0;
            activeSpeed = speed;
            moveDirection = Vector2.zero;
        }

        if (currentKnockTime > 0)
        {
            currentKnockTime -= Time.deltaTime;
        }
        else if (knocking)
        {
            knocking = false;
            currentKnockTime = 0;
            activeSpeed = speed;
        }
    }

    private void FixedUpdate() {
        Move();
    }

    public void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * activeSpeed, moveDirection.y * activeSpeed);
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
        activeSpeed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public virtual void SetDirection(Vector2 dir)
    {
        if (!dashing && !knocking)
        moveDirection = dir;
    }

    public Vector2 GetDirection()
    {
        return moveDirection;
    }

    public void Dash(Vector2 direction)
    {
        if (!dashing && !knocking)
        {
            dashing = true;
            currentDashTime = dashDuration;
            activeSpeed = dashSpeed;
            moveDirection = direction.normalized;
        }
        
    }

    public void Knock(float knockDuration, float knockSpeed, Vector2 direction)
    {
        knocking = true;
        currentKnockTime = knockDuration;
        activeSpeed = knockSpeed;
        moveDirection = direction.normalized;
    }

    public int GetMovementDirection()
    {
        if (moveDirection.x < 0) return -1;
        else if (moveDirection.x > 0) return 1;
        else return 0;
    }

}
