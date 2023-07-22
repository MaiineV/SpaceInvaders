using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    private View _view;
    private Controller _controller;

    public WeaponManager WeaponManager { get; private set; }

    [SerializeField] private float _velocity;
    [SerializeField] private Transform _shootingPoint;
    
    //Testing
    public Weapon testingWepaon;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        WeaponManager = new WeaponManager(_shootingPoint);
        _controller = new Controller(this);
    }

    private void Update()
    {
        _controller.OnUpdate();
        WeaponManager.OnUpdate();
    }

    public void Move(Vector3 dir)
    {
        _rigidbody.velocity = dir * _velocity;
    }
}
