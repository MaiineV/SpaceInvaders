using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour, IScreen
{
    public void ChangeLanguage(int value)
    {
        switch (value)
        {
            case 0:
                EventManager.Trigger("ChangeLanguage",Language.eng);
                break;
            case 1:
                EventManager.Trigger("ChangeLanguage",Language.spa);
                break;
            default:
                EventManager.Trigger("ChangeLanguage",Language.eng);
                break;
        }
    }

    public void ChangeSFXVolume(float value)
    {
        SoundManager.instance.ChangeVolumeSound(value);
    }
    
    public void ChangeMusicVolume(float value)
    {
        SoundManager.instance.ChangeVolumeMusic(value);
    }

    public void Return()
    {
        ScreenManager.Instance.Pop();
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
