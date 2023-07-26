using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _transform => transform;

    private Weapon _weapon;

    [SerializeField] private float _returnTime;
    private float _timer;
    
    private float _speed = 0;
    private float _dmg;

    private Vector3 _futurePos;
    private Collider[] _colliders;

    public void Init(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void SetDamage(float dmg)
    {
        _dmg = dmg;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetDir(Vector3 dir)
    {
        transform.forward = dir;
    }

    private void Update()
    {
        _colliders = Physics.OverlapSphere(_transform.position, 1, LayerManager.EnemyMask);
        if (_colliders.Length > 0)
        {
            Debug.Log(3);
            _colliders[0].gameObject.GetComponent<ILife>().Damage(_dmg);
            
            _weapon.ReturnBullet(this);
            return;
        }
        
        _transform.position += _transform.forward * (_speed * Time.deltaTime);

        _timer += Time.deltaTime;
        
        if (_timer > _returnTime) _weapon.ReturnBullet(this);
    }

    public void OnReset()
    {
        _timer = 0;
        _speed = 0;
    }

    public static void GetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.OnReset();
    }

    public static void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}
