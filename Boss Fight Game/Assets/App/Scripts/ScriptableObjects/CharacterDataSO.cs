using UnityEngine;


[CreateAssetMenu(fileName = "_CharacterDB", menuName = ("SciptableObjects/CharacterDB"))]
public class CharacterDataSO : ScriptableObject
{
    [SerializeField] private string characterName;
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private CharacterAnimSO animationsSO;
    [SerializeField] private float characterHealth = 100;
    [SerializeField] private float characterMana = 50;
    [SerializeField] private float characterEXP = 0;

    public string CharacterName { get => characterName; }
    public GameObject CharacterPrefab { get => characterPrefab; }
    public CharacterAnimSO AnimationSO { get => animationsSO; }
    public float CharacterHealth { get => characterHealth; }
    public float CharacterMana { get => characterMana; }
    public float CharacterEXP { get => characterEXP; }
}
