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

        public static void RaisOnCharacterSelectMenu()
        {
            OnCharacterSelectMenuEvent?.Invoke();
        }
        public static void RaisOnReturnToMainMenu()
        {
            OnReturnToMainMenuEvent?.Invoke();
        }

    }
}

