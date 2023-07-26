using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinuousMove : IMovement
{
    private float _currentDistance;
    private const float _maxHorizontalDist = 15;
    private Vector3 _currentHorizontalDir;
    
    private float _speed;
    public float Speed
    {
        set => _speed = value;
    }
    
    private readonly Transform _transform;
    public SinuousMove(Transform transform)
    {
        _transform = transform;
        _currentHorizontalDir = _transform.right;
    }

    public void Movement()
    {
        if (CheckCollisions())
        {
            _currentDistance = 0;
            _currentHorizontalDir *= -1;
        }
        
        var movementVector = (_transform.forward + _currentHorizontalDir) * _speed * Time.deltaTime;

        _currentDistance += movementVector.magnitude;
        _transform.position += movementVector;

        if (_currentDistance < _maxHorizontalDist) return;

        _currentDistance = 0;
        _currentHorizontalDir *= -1;
    }

    private bool CheckCollisions()
    {
        return Physics.CheckSphere(_transform.position, 5, LayerManager.ObstacleMask);
    }
}
