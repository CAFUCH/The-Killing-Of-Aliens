using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    private Rigidbody2D rb2d;
    [SerializeField] private float damage = 0f;
    private Vector2 minpos = Vector2.zero;
    private Vector2 maxpos = Vector2.zero;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        minpos = GameManager.Instance.Minpos.position;
        maxpos = GameManager.Instance.Maxpos.position;
    }
    private void Update()
    {
        Move();
        Block();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        rb2d.velocity = dir * speed;
    }
    private void Block()
    {
        Vector2 pos = transform.position;
        float x = Mathf.Clamp(pos.x, minpos.x, maxpos.x);
        float y = Mathf.Clamp(pos.y, minpos.y, maxpos.y);
        transform.position = new Vector3(x, y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamage id = other.GetComponent<IDamage>();
            if (id != null)
                id.OnDamage(damage);
        }
    }
}
