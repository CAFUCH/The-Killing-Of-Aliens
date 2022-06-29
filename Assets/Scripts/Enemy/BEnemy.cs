using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemy : MonoBehaviour
{
    protected PlayerHP playerHp = null;
    [SerializeField] protected float speed = 0f;
    [SerializeField] protected int damage = 0;
    protected Rigidbody2D rb2d = null;
    protected GameObject player = null;
    protected EnemySpawner enemySpawner = null;
    protected void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemySpawner = GameObject.Find("EnemySpawner1").GetComponent<EnemySpawner>();
    }
    protected virtual void Start()
    {
        player = GameManager.Instance.player;
        playerHp = GameManager.Instance.playerHp;
    }
    protected void Update()
    {
        Vector2 dir;
        dir = player.transform.position - transform.position;
        dir.Normalize();
        rb2d.velocity = dir * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IDamage id = other.GetComponent<IDamage>(); //부딪힌 새기 컴포넌트 Idamage 인터페이스를 받아온다
            if (id != null) //찾아졌을때 
                id.OnDamage(damage); //데미지 인터페이스 실행
        }
    }
}
