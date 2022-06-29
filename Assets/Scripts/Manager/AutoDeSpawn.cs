using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeSpawn : MonoBehaviour
{
    private Vector2 minpos = Vector2.zero;
    private Vector2 maxpos = Vector2.zero;
    private void Start()
    {
        minpos = GameManager.Instance.Minpos.position;
        maxpos = GameManager.Instance.Maxpos.position;
    }
    private void Update()
    {
        Vector2 pos = transform.position;
        if (pos.x < minpos.x || pos.x > maxpos.x || pos.y < minpos.y || pos.y > maxpos.y)
            PoolManager.Instance.DeSpawn(gameObject);
    }
}
