using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected SOWeapon _soWeapon;

    protected ObjectPool<Bullet> _bulletPool;

    private float _timer = 0;
    protected int _actualMagazine;

    protected Transform _shootingPoint;

    private void Awake()
    {
        _bulletPool =
            new ObjectPool<Bullet>(new Factory<Bullet>(BulletFactory), 10, Bullet.ReturnBullet, Bullet.GetBullet);
    }

    #region Weapon Interface

    public void OnEquip(Transform shootingPoint)
    {
        _shootingPoint = shootingPoint;
        
        _actualMagazine = _soWeapon.magazineSize;
    }

    public void OnUpdate()
    {
        _timer += Time.deltaTime;
    }
    
    public bool CanShoot
    {
        get
        {
            if (_timer < _soWeapon.shootTime || _actualMagazine <= 0) return false;
            
            _timer = 0;
            return true;
        }
    }

    public abstract void Shoot();

    public abstract WeaponsType Type();

    #endregion

    #region Pool&Factory

    private Bullet BulletFactory()
    {
        var resourceLoad = Resources.Load(_soWeapon.bulletPrefabName, typeof(GameObject)) as GameObject;

        if (!resourceLoad) return null;

        var instanceBullet = Instantiate(resourceLoad, _shootingPoint);
        var bullet = instanceBullet.GetComponent<Bullet>();

        if (!bullet) return null;
        
        bullet.Init(this);

        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        _bulletPool.ReturnObject(bullet);
    }

    #endregion

}
