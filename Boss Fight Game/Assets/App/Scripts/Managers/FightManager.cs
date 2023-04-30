using UnityEngine;
using BossFightGame.GameManager;
using BossFightGame.Events;

public class FightManager : MonoBehaviour
{
    [Header("PlayerLocations")]
    [SerializeField] private Transform playerLocation;
    [SerializeField] private Transform enemyLocation;

    [Header("Character References:")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

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
        GameObject enemy = Instantiate(enemyPrefab);

        enemy.transform.position = enemyLocation.position;

        enemy.transform.LookAt(playerLocation);
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
            playerData.CharacterName);
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
