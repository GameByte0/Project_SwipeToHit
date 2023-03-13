using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.UIEvents;
using System;

public class CharacterSelectMenuController : MonoBehaviour
{
    [SerializeField] private CharacterSelectMenuView view;


    private void OnEnable()
    {
        UIEvents.OnCharacterSelectMenuEvent += OnCharacterSelectMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnCharacterSelectMenuEvent -= OnCharacterSelectMenuEventHandler;
    }

    private void OnCharacterSelectMenuEventHandler()
    {
        view.gameObject.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        view.gameObject.SetActive(false);
        UIEvents.RaisOnReturnToMainMenu();
    }
}
