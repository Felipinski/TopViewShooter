using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Game/Configs/PoolConfig", order = 1)]

public class PoolConfig : ScriptableObject
{
    public string Key;
    public int MaxCapacity;
    public GameObject PrefabRef;

}
