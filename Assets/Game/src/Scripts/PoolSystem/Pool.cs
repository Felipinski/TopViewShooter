using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private string poolType;
    private int maxCapacity;
    private Queue<GameObject> gameObjects;

    public Pool(string poolType, int maxCapacity)
    {
        this.poolType = poolType;
        this.maxCapacity = maxCapacity;
        this.gameObjects = new Queue<GameObject>();
    }

    public void Add(GameObject gameObject)
    {
        Debug.Log("Adding object to " + poolType);

        if(this.gameObjects.Count < maxCapacity)
        {
            this.gameObjects.Enqueue(gameObject);
        }
        else
        {
            Debug.Log(poolType + "Pool is full");
        }

        Debug.Log(this.gameObjects.Count + "/" + maxCapacity);
    }

    public GameObject Get()
    {
        return this.gameObjects.Dequeue();
    }
}
