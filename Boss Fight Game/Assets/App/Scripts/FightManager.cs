using UnityEngine;

public class FightManager : MonoBehaviour
{
    [Header("PlayerLocations")]
    [SerializeField] private Transform playerLocation;
    [SerializeField] private Transform enemyLocation;

    [Header("Character References:")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = Instantiate(playerPrefab);

        player.transform.position = playerLocation.position;

        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = enemyLocation.position;
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
