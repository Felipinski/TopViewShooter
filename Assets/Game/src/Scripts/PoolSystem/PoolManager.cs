using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{   
    [SerializeField]
    private List<PoolConfig> poolConfigs = new List<PoolConfig>();
    [SerializeField]
    private Transform poolStorageTransform;

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
        foreach (PoolConfig poolConfig in poolConfigs)
        {
            pools.Add(poolConfig.Key, new Pool(poolConfig, poolStorageTransform));
        }
    }

    public void Add(string poolType, GameObject obj)
    {
        pools[poolType].Add(obj);
    }

    public GameObject GetFromPool(string poolType)
    {
        GameObject instance = pools[poolType].Get();
        instance.transform.SetParent(null);
        return instance;
    }
}
