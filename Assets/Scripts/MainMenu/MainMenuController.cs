using System;
using System.Collections;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Screens _initialScreen;
    
    private void Start()
    {
        StartCoroutine(LateStart());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
        }
    }

    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.5f);
        ScreenManager.Instance.Push(_initialScreen);
    }
}
