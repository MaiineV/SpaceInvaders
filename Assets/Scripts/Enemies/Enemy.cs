using UnityEngine;

public class Enemy : MonoBehaviour, ILife
{
    private EnemySpawner _spawner;

    [SerializeField] private GameObject[] _meshRenderers;
    [SerializeField] private BoxCollider _collider;
    private Vector3 _baseColliderSize;
    
    private float _life;
    private float _dmg;
    private float _attackSpeed;

    protected bool _isDeath = false;

    public void Init(EnemySpawner spawner)
    {
        _spawner = spawner;
        _baseColliderSize = _collider.size;
    }

    public void OnReset()
    {
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

    public void SetMesh(int mesh)
    {
        _meshRenderers[mesh].SetActive(true);
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
}

public enum EnemyType
{
    Asteroid,
    Base,
    Tank,
    Elite,
    Boss
}