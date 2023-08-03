using UnityEngine;
using BossFightGame.GameManager;
using BossFightGame.Events;

public class FightManager : MonoBehaviour
{
    [Header("FighterLocations")]
    [SerializeField] private Transform playerLocation;
    [SerializeField] private Transform enemyLocation;

    [Header("Turn-Based Action Parameters")]
    [SerializeField] private InteractionMenuController interactionMenu;

    private float turnDuration = 30f;
    private bool isPlayersTurn;

    [Header("Player Refs/Stats")]
    private int _playerHealth;
    private int _playerMana;
    private int _playerExp;
    private string _playerName;
    private int characterIndex; //index of selected character by player
    
    [Header("Enemy Refs/Stats")]
    private int _enemyHealth;
    private int _enemyMana;
    private int _enemyExp;
    private string _enemyName;
    private GameObject enemyRef;


    [Header("UI Reference")]
    [SerializeField] private InteractionMenuController timer;
    
    private void OnEnable()
    {
        GameEvents.OnApplyPercentageEvent += OnApplyPercentageEventHandler;
        GameEvents.OnChangeTurnEvent +=ChangeTurn;
    }
    private void OnDisable()
    {
        GameEvents.OnApplyPercentageEvent -= OnApplyPercentageEventHandler;
        GameEvents.OnChangeTurnEvent -= ChangeTurn;
    }

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");

        isPlayersTurn = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetPlayer();

        SetEnemy();
    }

    private void SetEnemy()
    {
        CharacterDataSO enemyData = GameManager.Instance.CharacterDataBase[Random.Range(0, 2)];

        GameObject enemyPrefab = Instantiate(enemyData.CharacterPrefab);

        enemyPrefab.AddComponent<EnemyControlller>();
        enemyRef = enemyPrefab;

        enemyPrefab.transform.position = enemyLocation.position;

        enemyPrefab.transform.LookAt(playerLocation);

        _enemyHealth = (int)enemyData.CharacterHealth;
        _enemyMana = (int)enemyData.CharacterMana;
        _enemyExp = (int)enemyData.CharacterEXP;
        _enemyName = enemyData.CharacterName;

        GameEvents.RaiseOnSettingStats(
            _enemyHealth,
            _enemyMana,
            _enemyExp,
            _enemyName, false);
    }
    private void SetPlayer()
    {
        CharacterDataSO playerData = GameManager.Instance.CharacterDataBase[characterIndex];

        GameObject playerPrefab = Instantiate( playerData.CharacterPrefab);

        playerPrefab.AddComponent<PlayerController>();
        playerPrefab.AddComponent<SwipeController>();

        playerPrefab.transform.position = playerLocation.position;

        playerPrefab.transform.LookAt(enemyLocation);

        _playerHealth = (int)playerData.CharacterHealth;
        _playerMana = (int)playerData.CharacterMana;
        _playerExp = (int)playerData.CharacterEXP;
        _playerName = playerData.CharacterName;

        GameEvents.RaiseOnSettingStats(
            _playerHealth,
            _playerMana,
            _playerExp,
            _playerName, true);
    }
  
    private void ChangeTurn()
    {
        isPlayersTurn = !isPlayersTurn;

        if (isPlayersTurn)
        {
            //its players turn to move
            interactionMenu.ActivateInteractions(true);

        }
        else
        {
            //enemy starts to doing action;
            interactionMenu.ActivateInteractions(false);
            enemyRef.GetComponent<EnemyControlller>().EnemyRandomAction();
        }
    }

    private void OnApplyPercentageEventHandler(float accuracy,int buttonIndex)
    {
        switch ((InteractionButtonTypes)buttonIndex)
        {
            case InteractionButtonTypes.Attcak:

                float damege = 20 * accuracy / 100;

                _enemyHealth -= (int)damege;

                GameEvents.RaiseOnEnemyChangeStats(_enemyHealth, _enemyMana);

                break;
            case InteractionButtonTypes.Defence:
                break;
            case InteractionButtonTypes.Item:
                break;
            default:
                break;
        }
    }
}
