using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.Events;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterAnimSO playerAnimationsSO;



    private void OnEnable()
    {
        GameEvents.OnSwipingEvent +=OnSwipingEventHandler;
    }
    private void OnDisable()
    {
        GameEvents.OnSwipingEvent -=OnSwipingEventHandler;
    }

    private void OnSwipingEventHandler(ActionTypes a)
    {
        animator.Play( playerAnimationsSO.PlayAnimation(a));
    }
    private void Start()
    {
        
    }

}
