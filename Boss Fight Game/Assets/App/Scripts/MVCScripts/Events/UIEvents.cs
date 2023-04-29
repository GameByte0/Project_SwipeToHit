using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BossFightGame.UIEvents
{
    public static class UIEvents
    {
        public delegate void OnCharacterSelectMenu();
        public static event OnCharacterSelectMenu OnCharacterSelectMenuEvent;

        public delegate void OnReturnToMainMenu();
        public static event OnReturnToMainMenu OnReturnToMainMenuEvent;

        public delegate void OnSettingsMenu();
        public static event OnSettingsMenu OnSettingsMenuEvent;

        public delegate void OnInteractionMenu();
        public static event OnInteractionMenu OnInteractionMenuEvent;

        public static void RaisOnCharacterSelectMenu()
        {
            OnCharacterSelectMenuEvent?.Invoke();
        }
        public static void RaisOnReturnToMainMenu()
        {
            OnReturnToMainMenuEvent?.Invoke();
        }
        public static void RaisOnSettingsMenu()
        {
            OnSettingsMenuEvent?.Invoke();
        }
        public static void RaisOnInteractionMenu()
        {
            OnInteractionMenuEvent?.Invoke();
        }
    }
}

