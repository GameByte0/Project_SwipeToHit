﻿using UnityEngine;
using System.Collections;
using BossFightGame.GameManager;
using BossFightGame.Events;
using BossFightGame.UIEvents;

public class FightManager : MonoBehaviour
{
    [Header("FighterLocations")]
    [SerializeField] private Transform playerLocation;
    [SerializeField] private Transform enemyLocation;

    [Header("Turn-Based Action Parameters")]
    [SerializeField] private InteractionMenuController interactionMenu;
    [SerializeField] private float _roundTime = 15;
    [SerializeField] private string enemyStatusText = "Enemy's Turn!!!";
    [SerializeField] private string playerStatusText = "Your Turn!!!";
    [SerializeField] private string gameOverStatusText = "GameOver!!!";
    [SerializeField] private string winStatusText = "You Win!!!";
    public float RoundTime { get => _roundTime; }
    private bool isPlayersTurn=true;

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


    private void OnEnable()
    {
        GameEvents.OnApplyPercentageEvent += OnApplyPercentageEventHandler;
        GameEvents.OnChangeTurnEvent += OnChangeTurnEventHandler;
        GameEvents.OnHitPlayerEvent += OnHitPlayerEventHandler;
    }
    private void OnDisable()
    {
        GameEvents.OnApplyPercentageEvent -= OnApplyPercentageEventHandler;
        GameEvents.OnChangeTurnEvent -= OnChangeTurnEventHandler;
        GameEvents.OnHitPlayerEvent -= OnHitPlayerEventHandler;
    }

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");

        isPlayersTurn = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartingGame());

        SetPlayer();

        SetEnemy();
    }

    private void SetEnemy()
    {
        int randomEnemyIndex = Random.Range(0, 2);
        CharacterDataSO enemyData = GameManager.Instance.CharacterDataBase[randomEnemyIndex];
        PlayerPrefs.SetInt("EnemyIndex", randomEnemyIndex);

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
        if (!isPlayersTurn)
        {
            //its players turn to move
            UIEvents.RaisOnGamestatusChange(playerStatusText,0);
            UIEvents.RaisOnInteractionMenu();
        }
        else
        {
            //enemy starts to doing action;
            UIEvents.RaisOnGamestatusChange(enemyStatusText,0);
            enemyRef.GetComponent<EnemyControlller>().IsRandomActionDone = true; //bad decision but works
        }
    }

    private void OnApplyPercentageEventHandler(float accuracy,int buttonIndex)
    {
        switch ((InteractionButtonTypes)buttonIndex)
        {
            case InteractionButtonTypes.Attaсk:

                float damege = 20 * accuracy / 100;

                _enemyHealth -= (int)damege;

                GameEvents.RaiseOnEnemyChangeStats(_enemyHealth, _enemyMana); //Updating enemy stats UI

                break;
            case InteractionButtonTypes.Defence:
                break;
            case InteractionButtonTypes.Item:
                break;
            default:
                break;
        }
    }
    private void OnHitPlayerEventHandler(int damage)
    {
        _playerHealth -= damage;
        GameEvents.RaiseOnPlayerChangeStats(_playerHealth, _playerMana);
    }
    private void OnChangeTurnEventHandler()
    {
        if (_playerHealth > 0 && _enemyHealth > 0)
        {
            ChangeTurn();
        }
        else if(_playerHealth <= 0)
        {
            UIEvents.RaisOnGamestatusChange(gameOverStatusText, 1);
            GameEvents.RaiseOnGameEnded();
            Time.timeScale = 0.1f;
        }
        else if(_enemyHealth <= 0)
        {
            UIEvents.RaisOnGamestatusChange(winStatusText, 1);
            GameEvents.RaiseOnGameEnded();
            Time.timeScale = 0.1f;
        }
    }

    private IEnumerator StartingGame()
    {
        yield return new WaitForSeconds(1f);
        ChangeTurn();
    }
}
