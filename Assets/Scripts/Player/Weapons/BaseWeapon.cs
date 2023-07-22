using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : Weapon
{
    public override void Shoot()
    {
        _actualMagazine--;
        
        var actualBullet = _bulletPool.GetObject();
        
        actualBullet.OnReset();
        actualBullet.SetPos(_shootingPoint.position);
        actualBullet.SetDir(_shootingPoint.forward);
        actualBullet.SetSpeed(10);
    }

    public override WeaponsType Type()
    {
        return WeaponsType.Base;
    }
}
