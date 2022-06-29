using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance = null;
    [SerializeField] private List <GameObject> prefabs = new List<GameObject> ();
    private Dictionary <string, Queue<GameObject>> pools = new Dictionary <string, Queue<GameObject>>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        foreach (GameObject prefab in prefabs)
        {
            Queue<GameObject> pool = new Queue<GameObject>();
            pools.Add(prefab.name, pool);
        }
    }
    public GameObject Spawn(GameObject item)
    {
        if(!pools.ContainsKey(item.name))
        {
            Debug.Log("풀링할 오브젝트를 리스트에서 찾을 수 없음!");
            Debug.Break();
        }
        GameObject obj = null;
        if (pools[item.name].Count > 0)
            obj = pools[item.name].Dequeue();
        else
        {
            obj = Instantiate(item, transform);
            obj.name = obj.name.Replace("(Clone)", null);
        }
        obj.SetActive(true);
        return obj;
    }
    public void DeSpawn(GameObject item)
    {
        item.SetActive(false);
        pools[item.name].Enqueue(item);
    }

}
