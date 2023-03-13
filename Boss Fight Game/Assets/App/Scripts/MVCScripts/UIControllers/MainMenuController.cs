using BossFightGame.UIEvents;
using UnityEngine;
using System;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private MainMenuView view;


    private void OnEnable()
    {
        UIEvents.OnReturnToMainMenuEvent += OnReturnToMainMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnReturnToMainMenuEvent -= OnReturnToMainMenuEventHandler;
    }

    private void OnReturnToMainMenuEventHandler()
    {
        view.gameObject.SetActive(true);
    }

    public void CharacterSelectPressed()
    {
        view.gameObject.SetActive(false);
        UIEvents.RaisOnCharacterSelectMenu();
    }
}
