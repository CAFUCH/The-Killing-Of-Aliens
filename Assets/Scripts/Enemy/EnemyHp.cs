using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : BEnemy, IDamage
{
    [SerializeField] private float healAmount = 0f;
    public void OnDamage(float damage)
    {
        ScoreManager.Instance.score += 15;
        PoolManager.Instance.DeSpawn(gameObject);
        playerHp.HpHeal(healAmount);
    }
}
