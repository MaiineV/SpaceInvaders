using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private Model _model;
    private Vector3 _dir;

    public Controller(Model model)
    {
        _model = model;
    }

    public void OnUpdate()
    {
        MovementInputs();
    }

    private void MovementInputs()
    {
        _dir = Vector3.zero;
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.z = Input.GetAxisRaw("Vertical");

        if (_dir.magnitude > 1)
            _dir.Normalize();

        _model.Move(_dir);
    }

    private void ShootInput()
    {
        if (Input.GetButton("Fire1"))
        {
            
        }
    }
}