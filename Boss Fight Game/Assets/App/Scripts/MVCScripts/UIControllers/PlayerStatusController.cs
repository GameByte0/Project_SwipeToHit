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
    }
    private void OnDisable()
    {
        GameEvents.OnSettingStatsEvent -= OnSettingStatsEventHandler;
        GameEvents.OnPlayerChangeStatsEvent -= OnPlayerChangeStatsEventHandler;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnPlayerChangeStatsEventHandler(int health,int mana)
    {
        view.ChangeStats(health, mana);
    }
}
