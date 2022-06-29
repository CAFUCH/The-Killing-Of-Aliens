using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDefault : BEnemy, IDamage
{
    public void OnDamage(float damage)
    {
        ScoreManager.Instance.score += 10;
        PoolManager.Instance.DeSpawn(gameObject);
    }
}
