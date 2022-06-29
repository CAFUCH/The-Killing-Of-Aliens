using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : BEnemy, IDamage
{
    public void OnDamage(float damage)
    {
        ScoreManager.Instance.score += 10;
        PoolManager.Instance.DeSpawn(gameObject);

    }
}
