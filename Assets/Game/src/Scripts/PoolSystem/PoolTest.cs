using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    public PoolManager pool;

    public void AddToPool(GameObject obj)
    {
        pool.Add("Bullet", obj);
    }

    public void GetFromPool(string poolType)
    {
        Instantiate(pool.GetFromPool(poolType));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
