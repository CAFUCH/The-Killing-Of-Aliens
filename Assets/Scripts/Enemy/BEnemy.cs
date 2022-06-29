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
            IDamage id = other.GetComponent<IDamage>(); //�ε��� ���� ������Ʈ Idamage �������̽��� �޾ƿ´�
            if (id != null) //ã�������� 
                id.OnDamage(damage); //������ �������̽� ����
        }
    }
}
