using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Screens
{
    Landing,
    Options,
    InGameUI,
    LoseScreen,
    WinScree
}

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _posibleScreens;
    private List<IScreen> _interfaceScreens = new List<IScreen>();
    
    private Stack<IScreen> _stack;

    public static ScreenManager Instance;
    
    private void Awake()
    {
        Instance = this;

        _stack = new Stack<IScreen>();

        foreach (var screen in _posibleScreens)
        {
            var tempInterface = screen.GetComponent<IScreen>();

            if (tempInterface == null) continue;
            
            _interfaceScreens.Add(tempInterface);
        }
    }

    public void Pop()
    {
        if (_stack.Count <= 1) return;

        _stack.Pop().Free();

        if (_stack.Count > 0)
        {
            _stack.Peek().Activate();
        }
    }

    public void Push(IScreen screen)
    {
        if (_stack.Count > 0)
        {
            _stack.Peek().Deactivate();
        }

        _stack.Push(screen);

        screen.Activate();
    }

    public void Push(Screens screen)
    {
        Push(_interfaceScreens[(int)screen]);
    }
  
}
