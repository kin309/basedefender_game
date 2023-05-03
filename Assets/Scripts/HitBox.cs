using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    Collider2D col;
    
    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<HurtBox>())
        {
            Debug.Log("Ye");
        }
    }
}
