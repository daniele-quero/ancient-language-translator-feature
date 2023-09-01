using System.Linq;
using TMPro;
using UnityEngine;
using static TMPro.TMP_Dropdown;

public class DropDown : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    private void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();

        foreach (var lan in LanguageDb.Instance.languageList)
            _dropdown.options.Add(new OptionData(lan.Name));
    }

    void Start()
    {
        SetCurrentLanguage();
        _dropdown.onValueChanged.AddListener(delegate { SetCurrentLanguage(); });
    }


    private void SetCurrentLanguage()
    {
        string name = _dropdown.options[_dropdown.value].text;
        var lan = LanguageDb.Instance.languageList.Select(l => l).Where(l => l.Name.Equals(name)).SingleOrDefault();

        if (lan != null)
        {
            UIManager.Instance.currentLanguage = lan;
            UIManager.Instance.currentProficiency.text = lan.Proficiency.ToString();
            UIManager.Instance.slider.value = lan.Proficiency * 10;
            UIManager.Instance.DoTranslate();
        }
    }
}
