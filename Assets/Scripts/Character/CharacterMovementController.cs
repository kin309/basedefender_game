using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MovementController
{
    float inputHorizontal, inputVertical;

    void Start()
    {
    }

    public void ProcessInputs(bool attacking)
    {
        MovementProcessing(attacking);
    }

    public void MovementProcessing(bool attacking)
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (!dashing && !knocking)
        {
            moveDirection = new Vector2(inputHorizontal, inputVertical).normalized;
        }
    }

}
