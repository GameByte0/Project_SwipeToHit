using System;

namespace BossFightGame.Events
{
    public static class GameEvents
    {
        public delegate void OnSwiping(ActionTypes eventDetails);
        public static event OnSwiping OnSwipingEvent;

        public delegate void OnSelectingFighter(bool eventDetails);
        public static event OnSelectingFighter OnSelectingFighterEvent;

        public delegate void OnSettingStats(int health, int mana, int exp, string name , bool isForPlayer);
        public static event OnSettingStats OnSettingStatsEvent;

        public static void RaiseOnSelectingFighter(bool i)
        {
            OnSelectingFighterEvent?.Invoke(i);
        }

        public static void RaiseOnSwiping(ActionTypes i)
        {
            OnSwipingEvent?.Invoke(i);
        }

        public static void RaiseOnSettingStats(int health, int mana, int exp, string name, bool isForPlayer)
        {
            OnSettingStatsEvent?.Invoke(health ,mana ,exp ,name ,isForPlayer );
        }

    }
    
}
public enum ActionTypes
{
    UP,
    RIGHT,
    DOWN,
    LEFT

}

