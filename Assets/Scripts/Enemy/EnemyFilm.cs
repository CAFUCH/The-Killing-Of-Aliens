using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFilm : BEnemy, IDamage
{
    public void OnDamage(float damage)
    {
        ScoreManager.Instance.score += 15;
        PoolManager.Instance.DeSpawn(gameObject);
        playerHp.FilmHeal();
    }
}
