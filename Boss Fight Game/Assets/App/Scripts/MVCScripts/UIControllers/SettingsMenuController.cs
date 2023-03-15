using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.UIEvents;
using System;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField] private SettingsMenuView view;

    private void OnEnable()
    {
        UIEvents.OnSettingsMenuEvent += OnSettingsMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnSettingsMenuEvent -= OnSettingsMenuEventHandler;
    }

    private void OnSettingsMenuEventHandler()
    {
        view.gameObject.SetActive(true);
    }
    public void ReturnToMainMenu()
    {
        view.gameObject.SetActive(false);
        UIEvents.RaisOnReturnToMainMenu();
    }
}
