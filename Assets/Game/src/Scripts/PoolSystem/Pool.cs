using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private string poolType;
    private int maxCapacity;
    private Queue<GameObject> gameObjects;
    private GameObject prefabRef;
    private Transform poolStorageTransform;

    public Pool(PoolConfig poolConfig, Transform poolStorageTransform)
    {
        this.poolType = poolConfig.Key;
        this.maxCapacity = poolConfig.MaxCapacity;
        this.prefabRef = poolConfig.PrefabRef;
        this.gameObjects = new Queue<GameObject>();
        this.poolStorageTransform = poolStorageTransform;
        PreWarm();
    }

    private void PreWarm(){
        for(int i=0;i<maxCapacity;i++)
        {
            GameObject instance = GameObject.Instantiate(prefabRef, poolStorageTransform);
            Add(instance);
        }
    }

    public void Add(GameObject gameObject)
    {
        Debug.Log("Adding object to " + poolType);

        if(gameObjects.Count < maxCapacity)
        {
            gameObject.SetActive(false);
            gameObjects.Enqueue(gameObject);
            gameObject.transform.SetParent(poolStorageTransform);
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
        return instance;
    }
}
