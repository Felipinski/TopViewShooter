using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private Dictionary<string, Pool> pools;

    void Awake()
    {
        pools = new Dictionary<string, Pool>();

        InitializePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializePool()
    {
        Pool bulletPool = new Pool("Bullet", 10);
        Pool enemyPool = new Pool("Enemy", 10);

        pools.Add("Bullet", bulletPool);
        pools.Add("Enemy", enemyPool);
    }

    public void Add(string poolType, GameObject obj)
    {
        pools[poolType].Add(obj);
    }

    public GameObject GetFromPool(string poolType)
    {
        return pools[poolType].Get();
    }
}
