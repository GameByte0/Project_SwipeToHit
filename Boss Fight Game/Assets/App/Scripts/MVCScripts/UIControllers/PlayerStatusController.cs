using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.Events;
using System;

public class PlayerStatusController : MonoBehaviour
{
    [SerializeField] private PlayerStatusView view;
    private void OnEnable()
    {
        GameEvents.OnSettingStatsEvent += OnSettingStatsEventHandler;
        GameEvents.OnPlayerChangeStatsEvent +=OnPlayerChangeStatsEventHandler;
        GameEvents.OnGameEndedEvent += OnGameEndedEventHandler;
    }
    private void OnDisable()
    {
        GameEvents.OnSettingStatsEvent -= OnSettingStatsEventHandler;
        GameEvents.OnPlayerChangeStatsEvent -= OnPlayerChangeStatsEventHandler;
        GameEvents.OnGameEndedEvent -= OnGameEndedEventHandler;
    }

    private void OnSettingStatsEventHandler(int health, int mana, int exp, string name, bool isForPlayer)
    {
        if (isForPlayer)
        {
            float level = exp / 10;
            if (level < 1)
            {
                level = 1;
            }
            view.SetStats(health, mana, (int)level, name);
        }
        
        
    }
    private void OnPlayerChangeStatsEventHandler(int health,int mana)
    {
        view.ChangeStats(health, mana);
    }
    private  void OnGameEndedEventHandler()
    {
        StartCoroutine(DeactivateView());
    }

    private IEnumerator  DeactivateView()
    {
        yield return new WaitForSeconds(0.1f);
        view.gameObject.SetActive(false);
    }
}
