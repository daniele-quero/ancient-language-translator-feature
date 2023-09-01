using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    private AncientText _at;

    public TMP_Text currentProficiency;
    public Language currentLanguage;
    public Slider slider;
    public TMP_InputField original;
    public TMP_InputField translated;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Missing UIManager");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        _at = original.GetComponent<AncientText>();
        SetAncientText();
    }

    private void Start()
    {
        slider.onValueChanged.AddListener((value) => SetProficiency(value / 10));
    }

    public void SetProficiency(float p)
    {
        LanguageDb.Instance.SetProficiency(currentLanguage.Id, p);
        currentLanguage = LanguageDb.Instance.GetById(currentLanguage.Id);
        currentProficiency.text = currentLanguage.Proficiency.ToString();

        DoTranslate();
    }

    public void AddProficiency(float dp)
    {
        SetProficiency(currentLanguage.Proficiency + dp);
        slider.value = currentLanguage.Proficiency * 10;
    }

    private void SetAncientText()
    {
        _at.text = original.text;
        _at.languageId = currentLanguage.Id;
    }

    public void DoTranslate()
    {
        SetAncientText();
        translated.text = Translator.Instance.Translate(_at);
    }
}
