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

        public delegate void OnApplyPercentage(float accuracy,int interacionButton);
        public static event OnApplyPercentage OnApplyPercentageEvent;

        public delegate void OnChangeStats(int health,int mana);
        public static event OnChangeStats OnEnemyChangeStatsEvent , OnPlayerChangeStatsEvent;

        public delegate void OnChangeTurn();
        public static event OnChangeTurn OnChangeTurnEvent;

        public delegate void OnHitPlayer(int damage);
        public static event OnHitPlayer OnHitPlayerEvent;

        public delegate void OnGameEnded();
        public static event OnGameEnded OnGameEndedEvent;


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

        public static void RaiseOnApplyPercentageEvent(float accuracy,int buttonIndex)
        {
            OnApplyPercentageEvent?.Invoke(accuracy,buttonIndex);
        }
        public static void RaiseOnEnemyChangeStats(int health, int mana)
        {
            OnEnemyChangeStatsEvent?.Invoke(health, mana);
        }
        public static void RaiseOnPlayerChangeStats(int health, int mana)
        {
            OnPlayerChangeStatsEvent?.Invoke(health, mana);
        }
        public static void RaiseOnChangeTurn()
        {
            OnChangeTurnEvent?.Invoke();
        }
        public static void RaiseOnHitPlayer(int damage)
        {
            OnHitPlayerEvent?.Invoke(damage);
        }
        public static void RaiseOnGameEnded()
        {
            OnGameEndedEvent?.Invoke();
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
public enum InteractionButtonTypes
{
    Attañk,
    Defence,
    Item
}

