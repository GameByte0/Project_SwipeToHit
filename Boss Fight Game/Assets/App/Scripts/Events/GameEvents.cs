using System;

namespace BossFightGame.Events
{
    public static class GameEvents
    {
        public delegate void OnSwiping(int a);
        public static event OnSwiping OnSwipingEvent;

        public static void RaiseOnSwiping(int i)
        {
            OnSwipingEvent?.Invoke(i);
        }

    }
}

