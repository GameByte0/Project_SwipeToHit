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
        if (view.gameObject.activeSelf)
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
            case InteractionButtonTypes.Attañk:
            case InteractionButtonTypes.Defence:
            case InteractionButtonTypes.Item:
                swipeChecker.ButtonIndex = buttonIndex;
                break;
            default:
                break;
        }
        view.gameObject.SetActive(false);
        swipeChecker.gameObject.SetActive(true);
        
    }
    private void StartTimer()
    {

        if (timeLeft >= 0)
        {
            
            timerIcon.fillAmount = timeLeft/fightManager.RoundTime;  //getting time percentage
            timeLeft -= Time.deltaTime;
            view.StartTimer(Mathf.RoundToInt(timeLeft));
        }
        else
        {
            GameEvents.RaiseOnChangeTurn();
            view.gameObject.SetActive(false);
            timeLeft = fightManager.RoundTime;
            timerIcon.fillAmount = 1;
        }

    }

   
}
