using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private SOLevel[] _levels;
    
    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }

        instance = this;
        
        EventManager.Subscribe("SetEnemySpawner", SetSpawnerReference);
    }

    private void SetSpawnerReference(params object[] parameters)
    {
        _enemySpawner = (EnemySpawner)parameters[0];
        _enemySpawner.ChangeLevel(_levels[0]);
    }

    public void OnAllEnemiesDeath()
    {
        ScreenManager.Instance.Push(Screens.WinScree);
    }
}
