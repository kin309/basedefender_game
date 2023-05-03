using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Character>())
        {
            var movement = other.GetComponent<MovementController>();
            movement.SetSpeed(movement.GetSpeed()*2f);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<Character>())
        {
            var movement = other.GetComponent<MovementController>();
            movement.SetSpeed(movement.GetSpeed()/2f);
        }
    }
}
