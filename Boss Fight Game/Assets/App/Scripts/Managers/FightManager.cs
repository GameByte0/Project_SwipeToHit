using UnityEngine;
using BossFightGame.GameManager;

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
        GameObject player = Instantiate(GameManager.Instance.CharacterDataBase[characterIndex].CharacterPrefab);

        player.AddComponent<PlayerController>();
        player.AddComponent<SwipeController>();

        player.transform.position = playerLocation.position;

        player.transform.LookAt(enemyLocation);
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
