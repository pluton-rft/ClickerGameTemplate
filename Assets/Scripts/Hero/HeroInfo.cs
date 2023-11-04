using UnityEngine;

[CreateAssetMenu(fileName = "HeroInfo", menuName = "Gameplay/New HeroInfo")]
public class HeroInfo : ScriptableObject {

    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private float _attack;
    [SerializeField] private int _levelAccess;
    [SerializeField] private int _price;
    [SerializeField] private int _rank;
    [SerializeField] private Sprite _image;

    public int id => _id;
    public string name => _name;
    public float attack => _attack;
    public int levelAccess => _levelAccess;
    public int price => _price;
    public int rank => _rank;
    public Sprite image => _image;

}
