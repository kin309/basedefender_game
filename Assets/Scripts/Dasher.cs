using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : MonoBehaviour
{
    [SerializeField] private Creature target;

    private void Start() {
        StartCoroutine(DashAttack(1.5f));
    }

    public IEnumerator DashAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        //GetComponent<MovementController>().Dash(0.3f, 15, target.transform.position - transform.position);
        StartCoroutine(DashAttack(1.5f));
    }
}
