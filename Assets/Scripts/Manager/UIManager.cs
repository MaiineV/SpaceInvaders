using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IScreen
{
    [SerializeField] private Image _lifeBar;
    [SerializeField] private Text _enemiesRemaining;
    
    private void Awake()
    {
        EventManager.Subscribe("LifeBar", LifeBar);
        EventManager.Subscribe("EnemyCounter", EnemiesRemaining);
    }

    private void LifeBar(params object[] parameters)
    {
        _lifeBar.fillAmount = (float)parameters[0];
    }

    private void EnemiesRemaining(params object[] parameters)
    {
        _enemiesRemaining.text = "Enemies Remaining: " + parameters[0].ToString();
    }
    
    public void Activate()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
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
