using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float delayTime = 0f;
    [SerializeField] private List<GameObject> enemys = new List<GameObject>();
    [SerializeField] private int MinType = 0;
    [SerializeField] private int MaxType = 3;
    public int enemyType = 0;
    private void Start()
    {
        StartCoroutine("Spawn");
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            #region 스위치
            //Types = Random.Range(1, 11);
            //switch(Types)
            //{
            //    case 1:
            //        Type = big;
            //        break;
            //    case 2:
            //    case 3:
            //        Type = white;
            //        break;
            //    case 4:
            //    case 5:
            //    case 6:
            //        Type = black;
            //        break;
            //    default:
            //        Type = enemys[enemyType];
            //        break;
            //}
            #endregion//스위치문 이였던 것
            enemyType = Random.Range(MinType, MaxType);
            GameObject item = PoolManager.Instance.Spawn(enemys[enemyType]);
            item.transform.position = transform.position;
            yield return new WaitForSeconds(delayTime);
        }
    }
}
