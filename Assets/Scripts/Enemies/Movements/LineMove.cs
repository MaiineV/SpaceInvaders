using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMove : IMovement
{
    private float _speed;
    public float Speed
    {
        set => _speed = value;
    }
    
    
    private Transform _transform;
    
    public LineMove(Transform transform)
    {
        _transform = transform;
    }
    
    public void Movement()
    {
        _transform.position += _transform.forward * (_speed * Time.deltaTime);
    }
}
