using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ILife
{
    private EnemySpawner _spawner;

    private readonly List<IMovement> _movements = new List<IMovement>();
    private IMovement _actualMovement;
    [SerializeField] private GameObject[] _meshRenderers;
    [SerializeField] private BoxCollider _collider;
    private Vector3 _baseColliderSize;
    
    [SerializeField] private float _life;
    [SerializeField] private float _dmg;
    [SerializeField] private float _attackSpeed;

    protected bool _isDeath = false;

    public void Init(EnemySpawner spawner)
    {
        _spawner = spawner;
        _baseColliderSize = _collider.size;
        
        _movements.Add(new LineMove(transform));
        _movements.Add(new SinuousMove(transform));
    }

    private void Update()
    {
        _actualMovement.Movement();
    }

    #region Builder

    public void OnReset()
    {
        _actualMovement = _movements[0];
        
        foreach (var meshRenderer in _meshRenderers)
        {
            meshRenderer.SetActive(false);
        }

        _life = 0;
        _dmg = 0;
        _attackSpeed = 0;

        _collider.size = _baseColliderSize;

        _isDeath = false;
    }

    public void SetMovement(int moveType)
    {
        if (_movements.Count <  moveType) return;
        
        _actualMovement = _movements[moveType];
    }

    public void SetMesh(int mesh)
    {
        _meshRenderers[mesh].SetActive(true);
    }

    public void SetSpeed(float speed)
    {
        foreach (var movement in _movements)
        {
            movement.Speed = speed;
        }
    }

    public void SetLife(float life)
    {
        _life = life;
    }

    public void SetDamage(float dmg)
    {
        _dmg = dmg;
    }

    public void SetAttackSpeed(float attackSpeed)
    {
        _attackSpeed = attackSpeed;
    }

    public void SetCollider(Vector3 size)
    {
        _collider.size = size;
    }

    #endregion
  

    #region Life Interface

    public void Damage(float dmg)
    {
        _life -= dmg;

        if (_life > 0) return;

        _isDeath = true;
        _spawner.ReturnEnemy(this);
    }

    public void Health(float health)
    {
        _life += health;
    }

    #endregion

    #region Pool Funcs

    public static void GetEnemy(Enemy enemy)
    {
        enemy.OnReset();
        enemy.gameObject.SetActive(true);
    }

    public static void ReturnEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 3) return;
        
        other.gameObject.GetComponent<IPlayerLife>().Damage(_dmg);
        _isDeath = true;
        _spawner.ReturnEnemy(this);
    }
}

public enum EnemyType
{
    Asteroid,
    Base,
    Tank,
    Elite,
    Boss
}