using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private string poolType;
    private int maxCapacity;
    private Queue<GameObject> gameObjects;
    private GameObject prefabRef;

    public Pool(PoolConfig poolConfig, Transform poolStorageTransform)
    {
        poolType = poolConfig.Key;
        maxCapacity = poolConfig.MaxCapacity;
        prefabRef = poolConfig.PrefabRef;
        gameObjects = new Queue<GameObject>();
        PreWarm(poolStorageTransform);
    }

    private void PreWarm(Transform poolStorageTransform){
        for(int i=0;i<maxCapacity;i++)
        {
            GameObject instance = GameObject.Instantiate(prefabRef, poolStorageTransform);
            instance.transform.SetParent(poolStorageTransform);
            Add(instance);
            instance.SetActive(false);
        }
    }

    public void Add(GameObject gameObject)
    {
        Debug.Log("Adding object to " + poolType);

        if(gameObjects.Count < maxCapacity)
        {
            gameObjects.Enqueue(gameObject);
        }
        else
        {
            Debug.Log(poolType + "Pool is full");
        }

        Debug.Log(gameObjects.Count + "/" + maxCapacity);
    }

    public GameObject Get()
    {   
        GameObject instance = gameObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }
}
