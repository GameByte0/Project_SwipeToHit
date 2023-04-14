using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.UIEvents;
using System;
using BossFightGame.Events;

public class CharacterSelectMenuController : MonoBehaviour
{
    [SerializeField] private CharacterSelectMenuView view;


    private void OnEnable()
    {
        UIEvents.OnCharacterSelectMenuEvent += OnCharacterSelectMenuEventHandler;
        GameEvents.OnSelectingFighterEvent += OnSelectingFighterEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnCharacterSelectMenuEvent -= OnCharacterSelectMenuEventHandler;
        GameEvents.OnSelectingFighterEvent -= OnSelectingFighterEventHandler;
    }

    private void OnSelectingFighterEventHandler(bool eventDetails)
    {
        if (eventDetails)
        {
            view.DisableCharacterSelection();
        }
        else
        {
            view.EnableCharacterSelection();
        }
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
