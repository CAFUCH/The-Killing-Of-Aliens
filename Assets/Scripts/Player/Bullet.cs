using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private float damage = 3f;
    private Rigidbody2D rb2d = null;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 dir = Vector2.up;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamage id = other.GetComponent<IDamage>();
            if(id != null)
                id.OnDamage(damage);
            PoolManager.Instance.DeSpawn(gameObject);
        }
    }
}
