using System;

namespace BossFightGame.Events
{
    public static class GameEvents
    {
        public delegate void OnSwiping(ActionTypes eventDetails);
        public static event OnSwiping OnSwipingEvent;

        public delegate void OnSelectingFighter(bool eventDetails);
        public static event OnSelectingFighter OnSelectingFighterEvent;

        public static void RaiseOnSelectingFighter(bool i)
        {
            OnSelectingFighterEvent?.Invoke(i);
        }

        public static void RaiseOnSwiping(ActionTypes i)
        {
            OnSwipingEvent?.Invoke(i);
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

