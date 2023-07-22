using UnityEngine;
public interface IWeapon
{
    public abstract void OnEquip(Transform shootingPoint);
    public abstract void OnUpdate();
    public abstract void Shoot();
    public bool CanShoot { get;}
    public WeaponsType Type();
}
