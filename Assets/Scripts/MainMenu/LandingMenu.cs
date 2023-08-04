using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingMenu : MonoBehaviour, IScreen
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        ScreenManager.Instance.Push(Screens.Options);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Activate()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        
        EventManager.Trigger("UpdateLanguage");
    }

    public void Deactivate()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void Free()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
