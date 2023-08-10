using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.UIEvents;
using BossFightGame.Events;
using System;
using UnityEngine.UI;

public class InteractionMenuController : MonoBehaviour
{
   [SerializeField] private InteractionMenuView view;
   [SerializeField] private SwipeChecker swipeChecker;
   [SerializeField] private FightManager fightManager;

    [SerializeField] private Image timerIcon; 
    private float timeLeft;

    private void OnEnable()
    {
        UIEvents.OnInteractionMenuEvent += OnInteractionMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnInteractionMenuEvent -= OnInteractionMenuEventHandler;
    }
    private void Start()
    {
        timeLeft = fightManager.RoundTime;
        timerIcon.fillAmount = 1;
    }
    private void Update()
    {
        if (view.IsViewActive)
        {
            StartTimer();
        }
        else
        {
            timeLeft = fightManager.RoundTime;
        }
    }

    private void OnInteractionMenuEventHandler()
    {
        view.gameObject.SetActive(true);
    }

    public void StartAction(int buttonIndex)
    {
        switch ((InteractionButtonTypes)buttonIndex)
        {
            case InteractionButtonTypes.Attcak:
            case InteractionButtonTypes.Defence:
            case InteractionButtonTypes.Item:
                swipeChecker.ButtonIndex = buttonIndex;
                break;
            default:
                break;
        }
        view.gameObject.SetActive(false);
        //here Rais event for swipe controller for showing combiniation
        swipeChecker.gameObject.SetActive(true);
        
    }
    public void ActivateInteractions(bool isActive)
    {
        //Debug.Log("activate UI --" + isActive);
        view.gameObject.SetActive(isActive);
        
    }
    private void StartTimer()
    {

        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            timerIcon.fillAmount = timeLeft/fightManager.RoundTime;  
           // Debug.Log(timerIcon.fillAmount);
            view.StartTimer((int)timeLeft);
        }
        else
        {
            GameEvents.RaiseOnChangeTurn();
            timeLeft = fightManager.RoundTime;
            timerIcon.fillAmount = 1;
        }

    }

   
}
