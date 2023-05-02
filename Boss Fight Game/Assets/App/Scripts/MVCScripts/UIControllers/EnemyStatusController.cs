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
    }
    private void OnDisable()
    {
        GameEvents.OnSettingStatsEvent -= OnSettingStatsEventHandler;
    }

    private void OnSettingStatsEventHandler(int health, int mana, int exp, string name, bool isForPlayer)
    {
        if (!isForPlayer)
        {
            view.SetStats(health, mana, name);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
