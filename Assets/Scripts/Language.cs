using UnityEngine;

[System.Serializable]
public class Language
{
    [SerializeField] private string _name;
    [SerializeField] private int _id;
    [SerializeField] private float _proficiency;

    public string Name { get => _name; set => _name = value; }
    public int Id { get => _id; set => _id = value; }
    public float Proficiency
    {
        get { return Mathf.Clamp01(_proficiency); }
        set { _proficiency = value; _proficiency = Mathf.Round(Mathf.Clamp01(_proficiency) * 10) / 10; }
    }
}
