using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    public PoolManager poolManager;

    public void AddToPool(GameObject obj)
    {
        poolManager.Add("bullet", obj);
    }

    public void GetFromPool(string poolType)
    {
        Instantiate(poolManager.GetFromPool(poolType));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            GameObject bullet = poolManager.GetFromPool("bullet");
            bullet.transform.position = transform.position;
        }
    }
}
