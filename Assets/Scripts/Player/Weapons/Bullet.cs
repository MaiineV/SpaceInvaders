using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _transform => transform;

    private Weapon _weapon;

    [SerializeField] private float _returnTime;
    private float _timer;
    
    private float _speed = 0;

    private Vector3 _futurePos;
    private RaycastHit[] _hit;

    public void Init(Weapon weapon)
    {
        _weapon = weapon;
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
        _futurePos = _transform.position += _transform.forward * (_speed * Time.deltaTime);
        
        if (Physics.CapsuleCastNonAlloc(_transform.position, _futurePos, 1, _transform.forward, _hit, LayerManager.EnemyMask) > 0)
        {
            //TODO: Damage To Enemy
            
            _weapon.ReturnBullet(this);
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
