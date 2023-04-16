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
        GameObject player = Instantiate(GameManager.Instance.CharacterDataBase[characterIndex].CharacterPrefab);

        player.transform.position = playerLocation.position;

        player.transform.LookAt(enemyLocation);
        //player.transform.rotation = playerLocation.rotation;

        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = enemyLocation.position;

        enemy.transform.LookAt(playerLocation);
    }

    // Update is called once per frame
    void Update()
    {

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
