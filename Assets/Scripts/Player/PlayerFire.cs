using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private float delayTime = 0f;
    [SerializeField] private List<GameObject> bullets = new List<GameObject>();
    public int bulletType = 0;
    private void Start()
    {
        StartCoroutine(Fire());
    }
    private void Update()
    {
        Change();
    }
    private void Change()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (bulletType == 2)
                bulletType = 0;
            else { bulletType++; }
        }
    }
    IEnumerator Fire()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
                || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector3 rotate = new Vector3();
                if (Input.GetKeyDown(KeyCode.UpArrow)) rotate.z = 0;
                if (Input.GetKeyDown(KeyCode.DownArrow)) rotate.z = 180;
                if (Input.GetKeyDown(KeyCode.LeftArrow)) rotate.z = 90;
                if (Input.GetKeyDown(KeyCode.RightArrow)) rotate.z = 270;

                GameObject item =  PoolManager.Instance.Spawn(bullets[bulletType]);
                item.transform.position = transform.position;
                item.transform.eulerAngles = rotate;

                yield return new WaitForSeconds(delayTime);
            }
            yield return null;
        }
    }
}
