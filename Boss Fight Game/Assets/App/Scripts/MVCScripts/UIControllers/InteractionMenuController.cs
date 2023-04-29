using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.UIEvents;
using BossFightGame.Events;
using System;

public class InteractionMenuController : MonoBehaviour
{
   [SerializeField] private InteractionMenuView view;
    [SerializeField] private SwipeChecker swipeChecker; 

    private void OnEnable()
    {
        UIEvents.OnInteractionMenuEvent += OnInteractionMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnInteractionMenuEvent -= OnInteractionMenuEventHandler;
    }

    private void OnInteractionMenuEventHandler()
    {
        view.gameObject.SetActive(true);
    }

    public void StartAction()
    {
        view.gameObject.SetActive(false);
        //here Rais event for swipe controller for showing combiniation
        swipeChecker.gameObject.SetActive(true);
    }
   
}
