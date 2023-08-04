using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private LookUpTable<string, EnemyType> _enemyLevelTable;
    private ObjectPool<Enemy> _enemyPool;

    private readonly List<Transform> _spawnsPoint = new List<Transform>();

    private int _actualLevel;
    private int _maxEnemiesInLevel;
    private int _enemiesInLevel;
    private readonly StringBuilder _levelStringBuilder = new StringBuilder();

    private bool _isActive = false;
    [SerializeField] private float _spawnCD;
    private float _timer;

    private void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>(new Factory<Enemy>(EnemyFactory), 20, Enemy.ReturnEnemy, Enemy.GetEnemy);
        _enemyLevelTable = new LookUpTable<string, EnemyType>(TableFactory);

        foreach (var child in transform)
        {
            _spawnsPoint.Add((Transform)child);
        }
    }

    private void Start()
    {
        EventManager.Trigger("SetEnemySpawner", this);
    }

    private void Update()
    {
        if (!_isActive) return;

        _timer += Time.deltaTime;

        if (_timer < _spawnCD) return;

        _levelStringBuilder.Clear();

        _levelStringBuilder.Append(_actualLevel);
        _levelStringBuilder.Append(",");
        _levelStringBuilder.Append(_maxEnemiesInLevel);

        var enemyType = Random.Range(0, 4);

        switch (enemyType)
        {
            case 0:
                SpawnEnemy(EnemyType.Asteroid);
                break;
            case 1:
                SpawnEnemy(EnemyType.Base);
                break;
            case 2:
                SpawnEnemy(EnemyType.Tank);
                break;
            case 3:
                SpawnEnemy(EnemyType.Elite);
                break;

        }

        _timer = 0;
    }

    public void ChangeLevel(SOLevel newLevel)
    {
        _timer = 0;

        if (newLevel.isBossLevel)
        {
            _isActive = false;
            SpawnEnemy(EnemyType.Boss);
        }
        else
        {
            _actualLevel = newLevel.level;
            _spawnCD = newLevel.spawnTime;
            _maxEnemiesInLevel = newLevel.enemiesInLevel;
            _enemiesInLevel = _maxEnemiesInLevel;
            _isActive = true;
            
            EventManager.Trigger("EnemyCounter", _enemiesInLevel.ToString());
        }
    }

    private void SpawnEnemy(EnemyType value)
    {
        var actualEnemy = _enemyPool.GetObject();

        var spawnIndex = Random.Range(0, _spawnsPoint.Count);
        actualEnemy.transform.position = _spawnsPoint[spawnIndex].position;
        actualEnemy.transform.rotation = _spawnsPoint[spawnIndex].rotation;

        var index = (int)value;

        actualEnemy.SetMesh(index);
        FlyWeight.EnemyDataGetter(actualEnemy, value);
    }

    #region Pool&Factory

    private Enemy EnemyFactory()
    {
        var enemyGO = Instantiate(Resources.Load("Enemy")) as GameObject;

        if (!enemyGO) return null;

        var enemy = enemyGO.GetComponent<Enemy>();

        if (!enemyGO) return null;

        enemy.Init(this);

        return enemy;
    }

    public void ReturnEnemy(Enemy enemy)
    {
        _enemyPool.ReturnObject(enemy);
        _enemiesInLevel--;
        EventManager.Trigger("EnemyCounter", _enemiesInLevel);

        if (_enemiesInLevel > 0) return;

        GameManager.instance.OnAllEnemiesDeath();
        _isActive = false;
    }

    #endregion

    #region Table

    private EnemyType TableFactory(string input)
    {
        var split = input.Split(',');

        var level = int.Parse(split[0]);
        var enemyInLevel = int.Parse(split[1]);

        var result = 50;

        if (result < 40)
        {
            return EnemyType.Asteroid;
        }

        if (result < 70)
        {
            return EnemyType.Base;
        }

        if (result < 90)
        {
            return EnemyType.Tank;
        }

        return EnemyType.Elite;
    }

    #endregion
}