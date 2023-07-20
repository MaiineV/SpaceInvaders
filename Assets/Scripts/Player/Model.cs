using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private View _view;
    private Controller _controller;

    [SerializeField] private float _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _controller = new Controller(this);
    }

    private void Update()
    {
        _controller.OnUpdate();
    }

    public void Move(Vector3 dir)
    {
        _rigidbody.velocity = dir * _velocity;
    }
}
