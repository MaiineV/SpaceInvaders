using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public abstract void Movement();
    public abstract float Speed { set; }
}
