using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeight : MonoBehaviour
{
    [SerializeField] private string _asteroidSOPath;
    private static EnemyFlyWeight AsteroidEnemy = new EnemyFlyWeight();

    [SerializeField] private string _baseSOPath;
    private static EnemyFlyWeight BaseEnemy = new EnemyFlyWeight();

    [SerializeField] private string _tankSOPath;
    private static EnemyFlyWeight TankEnemy = new EnemyFlyWeight();

    [SerializeField] private string _eliteSOPath;
    private static EnemyFlyWeight EliteEnemy = new EnemyFlyWeight();

    [SerializeField] private string _bossSOPath;
    private static EnemyFlyWeight BossEnemy = new EnemyFlyWeight();

    private void Awake()
    {
        var asteroidSO = Resources.Load(_asteroidSOPath) as SOEnemy;

        if (asteroidSO)
            AsteroidEnemy = new EnemyFlyWeight
            {
                life = asteroidSO.life,
                speed = asteroidSO.speed,
                dmg = asteroidSO.dmg,
                colliderSize = asteroidSO.colliderSize
            };

        var baseSO = Resources.Load(_baseSOPath) as SOEnemy;

        if (baseSO)
            BaseEnemy = new EnemyFlyWeight
            {
                life = baseSO.life,
                speed = baseSO.speed,
                dmg = baseSO.dmg,
                attackSpeed = baseSO.attackSpeed,
                colliderSize = baseSO.colliderSize
            };

        var tankSO = Resources.Load(_tankSOPath) as SOEnemy;

        if (tankSO)
            TankEnemy = new EnemyFlyWeight
            {
                life = tankSO.life,
                speed = tankSO.speed,
                dmg = tankSO.dmg,
                attackSpeed = tankSO.attackSpeed,
                colliderSize = tankSO.colliderSize
            };

        var eliteSO = Resources.Load(_eliteSOPath) as SOEnemy;

        if (eliteSO)
            EliteEnemy = new EnemyFlyWeight
            {
                life = eliteSO.life,
                speed = eliteSO.speed,
                dmg = eliteSO.dmg,
                attackSpeed = eliteSO.attackSpeed,
                colliderSize = eliteSO.colliderSize
            };

        var bossSO = Resources.Load(_bossSOPath) as SOEnemy;

        if (bossSO)
            BossEnemy = new EnemyFlyWeight
            {
                life = bossSO.life,
                speed = bossSO.speed,
                dmg = bossSO.dmg,
                attackSpeed = bossSO.attackSpeed,
                colliderSize = bossSO.colliderSize
            };
    }

    public static void EnemyDataGetter(Enemy enemy, EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Asteroid:
                enemy.SetLife(AsteroidEnemy.life);
                enemy.SetDamage(AsteroidEnemy.dmg);
                enemy.SetSpeed(AsteroidEnemy.speed);
                break;
            case EnemyType.Base:
                enemy.SetLife(BaseEnemy.life);
                enemy.SetDamage(BaseEnemy.dmg);
                enemy.SetSpeed(BaseEnemy.speed);
                enemy.SetAttackSpeed(BaseEnemy.attackSpeed);
                enemy.SetCollider(BaseEnemy.colliderSize);
                break;
            case EnemyType.Tank:
                enemy.SetLife(TankEnemy.life);
                enemy.SetDamage(TankEnemy.dmg);
                enemy.SetSpeed(TankEnemy.speed);
                enemy.SetAttackSpeed(TankEnemy.attackSpeed);
                enemy.SetCollider(TankEnemy.colliderSize);
                break;
            case EnemyType.Elite:
                enemy.SetLife(EliteEnemy.life);
                enemy.SetDamage(EliteEnemy.dmg);
                enemy.SetSpeed(EliteEnemy.speed);
                enemy.SetAttackSpeed(EliteEnemy.attackSpeed);
                enemy.SetCollider(EliteEnemy.colliderSize);
                enemy.SetMovement(1);
                break;
            case EnemyType.Boss:
                enemy.SetLife(BossEnemy.life);
                enemy.SetDamage(BossEnemy.dmg);
                enemy.SetSpeed(BossEnemy.speed);
                enemy.SetAttackSpeed(BossEnemy.attackSpeed);
                enemy.SetCollider(BossEnemy.colliderSize);
                break;
            default:
                break;
        }
    }
}

public class EnemyFlyWeight
{
    public float life;
    public float speed;
    public float dmg;
    public float attackSpeed;
    public Vector3 colliderSize;
}
