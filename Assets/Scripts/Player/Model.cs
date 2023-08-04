using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Model : MonoBehaviour, IPlayerLife
{
    private Rigidbody _rigidbody;
    
    private View _view;
    private Controller _controller;

    public WeaponManager WeaponManager { get; private set; }

    [SerializeField] private float _maxLife;
    private float _life;

    private float Life
    {
        get => _life;
        set
        {
            _life = value;

            _life = Mathf.Clamp(_life, 0, _maxLife);
            
            EventManager.Trigger("LifeBar", (_life / _maxLife));

            if (_life <= 0)
            {
                OnDeath();
            }
        }
    }
    
    
    [SerializeField] private float _velocity;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private Weapon _initialWeapon;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        WeaponManager = new WeaponManager(_shootingPoint);
        _controller = new Controller(this);
        
        WeaponManager.AddWeapon(_initialWeapon);

        Life = _maxLife;
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

    private void OnDeath()
    {
        Time.timeScale = 0;
        ScreenManager.Instance.Push(Screens.LoseScreen);
    }

    public void Damage(float dmg)
    {
        Life -= dmg;
    }

    public void Health(float health)
    {
        Life += health;
    }
}
