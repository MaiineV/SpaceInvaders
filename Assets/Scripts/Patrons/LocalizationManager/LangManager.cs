using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public enum Language
{
    eng,
    spa
}

public class LangManager : MonoBehaviour
{
    [SerializeField] private Language _selectedLanguage;
    
    [SerializeField] private string _externalURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vT8DKbbI6pv2Ld2rneeirEA8Fm2Y4HZXZLnlYa3urT1FUn2-xeFOIzdA_dg5oEE4lapfN2Kf93S5mUA/pub?gid=901342671&single=true&output=csv";

    private Dictionary<Language, Dictionary<string, string>> _languageManager;

    public event Action onUpdate = delegate { };

    private void Awake()
    {
        EventManager.Subscribe("ChangeLanguage", ChangeLanguage);
        EventManager.Subscribe("UpdateLanguage", UpdateLanguage);
    }

    private void Start()
    {
        StartCoroutine(DownloadCSV(_externalURL));
    }

    // private void Update()
    // {
    //     // if (Input.GetKeyDown(KeyCode.F))
    //     // {
    //     //     if (_selectedLanguage == Language.eng)
    //     //         _selectedLanguage = Language.spa;
    //     //     else
    //     //         _selectedLanguage = Language.eng;
    //     //
    //     //     onUpdate();
    //     // }
    // }

    private void ChangeLanguage(params object[] parameters)
    {
        var language = (Language)parameters[0];
        _selectedLanguage = language;
        onUpdate();
    }

    private void UpdateLanguage(params object[] parameters)
    {
        onUpdate();
    }

    public string GetTranslate(string id)
    {
        if (!_languageManager[_selectedLanguage].ContainsKey(id))
        {
            return "Error 404: Not Found";
        }
        else
        {
            return _languageManager[_selectedLanguage][id];
        }
    }

    private IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        _languageManager = LanguageU.LoadCodexFromString("www", www.downloadHandler.text);

        onUpdate();
    }

}
