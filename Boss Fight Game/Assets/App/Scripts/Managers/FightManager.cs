using UnityEngine;
using BossFightGame.GameManager;
using BossFightGame.Events;

public class FightManager : MonoBehaviour
{
    [Header("PlayerLocations")]
    [SerializeField] private Transform playerLocation;
    [SerializeField] private Transform enemyLocation;


    private int characterIndex;
    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");
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

        enemyPrefab.transform.position = enemyLocation.position;

        enemyPrefab.transform.LookAt(playerLocation);

        GameEvents.RaiseOnSettingStats(
            (int)enemyData.CharacterHealth,
            (int)enemyData.CharacterMana,
            (int)enemyData.CharacterEXP,
            enemyData.CharacterName, false);
    }

    private void SetPlayer()
    {
        CharacterDataSO playerData = GameManager.Instance.CharacterDataBase[characterIndex];

        GameObject playerPrefab = Instantiate( playerData.CharacterPrefab);

        playerPrefab.AddComponent<PlayerController>();
        playerPrefab.AddComponent<SwipeController>();

        playerPrefab.transform.position = playerLocation.position;

        playerPrefab.transform.LookAt(enemyLocation);

        GameEvents.RaiseOnSettingStats(
            (int)playerData.CharacterHealth,
            (int)playerData.CharacterMana,
            (int)playerData.CharacterEXP,
            playerData.CharacterName,true);
    }
    public Transform GetPlayerLoc()
    {
        return playerLocation;
    }
    public Transform GetEnemyLoc()
    {
        return enemyLocation;
    }
}
