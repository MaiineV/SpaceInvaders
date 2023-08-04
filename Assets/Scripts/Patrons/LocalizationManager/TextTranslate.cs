using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TextTranslate : MonoBehaviour
{
    [SerializeField] private string _id;

    [SerializeField] private LangManager _manager;

    [SerializeField] private Text _myView;

    private void Awake()
    {
        _manager.onUpdate += ChangeLang;
    }

    private void ChangeLang()
    {
        //var value = int.Parse(_manager.GetTranslate(_ID));

        _myView.text = _manager.GetTranslate(_id);
    }

    private void OnDisable()
    {
        _manager.onUpdate -= ChangeLang;
    }
}
