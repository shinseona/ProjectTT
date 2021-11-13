using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Video;

public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager Instance { get; private set; }
    public List<EnemyPool> enemyPool;
    private Dictionary<int,EnemyPool> enemyDictionary 
        = new Dictionary<int, EnemyPool>();
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }

    void Start()
    {
        foreach (var i in enemyPool)
        {
            enemyDictionary.Add(i.EnemyPoolable.Enemy_ID, i);
        }
    }


    private GameObject EnemyPop(int _enemyID)
    {
        foreach (var i in enemyDictionary)
        {
            if (i.Key == _enemyID)
            {
                return i.Value.Pop();
            }
        }

        return null;
    }

    public static GameObject Static_EnemyPop(int _enemyID)
    {
       return Instance.EnemyPop(_enemyID);
    }
}
