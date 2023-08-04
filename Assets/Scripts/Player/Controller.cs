using UnityEngine;

public class Controller
{
    private readonly Model _model;
    private Vector3 _dir;

    public Controller(Model model)
    {
        _model = model;
    }

    public void OnUpdate()
    {
        MovementInputs();
        ShootInput();
        
        //Testing Zone
        //TestingInputs();
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
        if (Input.GetButton("Fire1") && _model.WeaponManager.CanShoot())
        {
            _model.WeaponManager.Shoot();
        }
    }

    // private void TestingInputs()
    // {
    //     if (Input.GetKeyDown(KeyCode.L))
    //     {
    //         _model.WeaponManager.AddWeapon(_model.testingWepaon);
    //     }
    // }
}