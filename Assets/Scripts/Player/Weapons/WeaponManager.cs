using System.Collections.Generic;
using UnityEngine;

public class WeaponManager
{
    private IWeapon _actualWeapon;
    private readonly Dictionary<WeaponsType, IWeapon> _equippedWeapon = new Dictionary<WeaponsType, IWeapon>();

    private Transform _shootingPoint;
    
    public WeaponManager(Transform shootingPoint)
    {
        _shootingPoint = shootingPoint;
    }

    public void OnUpdate()
    {
        _actualWeapon?.OnUpdate();
    }

    public void Shoot()
    {
        _actualWeapon?.Shoot();
    }

    public bool CanShoot()
    {
        return _actualWeapon?.CanShoot ?? false;
    }

    public void AddWeapon(IWeapon weapon)
    {
        if (_equippedWeapon.ContainsKey(weapon.Type())) return;

        _equippedWeapon.Add(weapon.Type(), weapon);

        if (_actualWeapon == null) EquipWeapon(weapon);
    }

    public void EquipWeapon(WeaponsType weapon)
    {
        if (!_equippedWeapon.ContainsKey(weapon)) return;

        _actualWeapon = _equippedWeapon[weapon];
        _actualWeapon.OnEquip(_shootingPoint);
    }
    
    public void EquipWeapon(IWeapon weapon)
    {
        if (!_equippedWeapon.ContainsValue(weapon)) _equippedWeapon.Add(weapon.Type(), weapon);;

        _actualWeapon = weapon;
        _actualWeapon.OnEquip(_shootingPoint);
    }
}

public enum WeaponsType
{
    Base,
    Rapid,
    Multi,
    Explosive
}
