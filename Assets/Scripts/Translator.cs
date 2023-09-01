using AncientLanguageUtils;
using UnityEngine;

public class Translator : MonoBehaviour
{
    private static Translator _instance;

    public static Translator Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Missing Translator");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public string Translate(AncientText at)
    {
        float proficiency = GetProficiency(at);
        return proficiency == 0 ? CoverText.CoverTextWith(at.text, "x") : TranslateByProficiency(at.text, proficiency);
    }

    private float GetProficiency(AncientText at)
    {
        var lan = LanguageDb.Instance.GetById(at.languageId);
        if (lan != null) return lan.Proficiency;
        return 0;
    }

    private string TranslateByProficiency(string s, float p)
    {
        if (p == 1) return s;

        var words = s.Split(" ");
        for (int i = 0; i < words.Length; i++)
        {
            if (Random.value > p)
            {
                var array = words[i].ToCharArray();
                Durstenfeld<char>.shuffle(array);
                words[i] = new string(array);
            }
        }

        return string.Join(" ", words);
    }

}

