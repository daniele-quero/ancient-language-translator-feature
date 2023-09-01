using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LanguageDb : MonoBehaviour
{
    private static LanguageDb _instance;

    public static LanguageDb Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Missing LanguageDb");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public List<Language> languageList;

    public void SetProficiency(int id, float p)
    {
        var lan = GetById(id);
        if (lan != null) lan.Proficiency = p;
    }

    public Language GetById(int id)
    {
        return languageList.Select(l => l).Where(l => l.Id == id).Single();
    }
}
