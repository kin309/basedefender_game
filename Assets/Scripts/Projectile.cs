using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 direction;
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float knockSpeed;
    [SerializeField] float knockDuration;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDestruct(3));
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.position += direction * speed/10;
    }

    public void Define(Vector3 _direction, float _damage)
    {
        direction = _direction.normalized;
        damage = _damage;
    }

    public IEnumerator SelfDestruct(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 3)
        {
            if(other.GetComponent<Entity>() != null)
            {
                other.GetComponent<Entity>().TakeDamage(damage, knockDuration, knockSpeed, direction);
            }
            StartCoroutine(SelfDestruct(0));
        }
    }
}
