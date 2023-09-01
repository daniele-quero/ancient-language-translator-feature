using AncientLanguageUtils;
using UnityEngine;

public class Test : MonoBehaviour
{
    public string test = "supergalactic";
    void Start()
    {
        var array = test.ToCharArray();
        Durstenfeld<char>.shuffle(array);
        Debug.Log(new string(array));


        AncientText at = GetComponent<AncientText>();
        Debug.Log(Translator.Instance.Translate(at));
    }
}
