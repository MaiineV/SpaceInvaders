using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerLife
{
    public abstract void Damage(float dmg);
    public abstract void Health(float health);
}
