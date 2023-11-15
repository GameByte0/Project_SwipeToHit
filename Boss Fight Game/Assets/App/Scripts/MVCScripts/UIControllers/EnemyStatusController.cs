using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.Events;
using System;

public class EnemyStatusController : MonoBehaviour
{
    [SerializeField] private EnemyStatusView view;


    private void OnEnable()
    {
        GameEvents.OnSettingStatsEvent += OnSettingStatsEventHandler;
        GameEvents.OnEnemyChangeStatsEvent += OnEnemyChangeStatsEventHandler;
        GameEvents.OnGameEndedEvent += OnGameEndedEventHandler;
    }
    private void OnDisable()
    {
        GameEvents.OnSettingStatsEvent -= OnSettingStatsEventHandler;
        GameEvents.OnEnemyChangeStatsEvent -= OnEnemyChangeStatsEventHandler;
        GameEvents.OnGameEndedEvent -= OnGameEndedEventHandler;
    }

    private void OnEnemyChangeStatsEventHandler(int health, int mana)
    {
        view.ChangeStats(health, mana);
    }

    private void OnSettingStatsEventHandler(int health, int mana, int exp, string name, bool isForPlayer)
    {
        if (!isForPlayer)
        {
            view.SetStats(health, mana, name);
        }
    }
    private void OnGameEndedEventHandler()
    {
        StartCoroutine(DeactivateView());
    }

    private IEnumerator DeactivateView()
    {
        yield return new WaitForSeconds(0.1f);
        view.gameObject.SetActive(false);
    }

}
