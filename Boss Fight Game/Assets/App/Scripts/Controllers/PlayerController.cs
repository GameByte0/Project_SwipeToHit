using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.Events;
using BossFightGame.GameManager;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Animation")]
    private Animator animator;
    private CharacterAnimSO playerAnimationsSO;

    private CharacterDataSO characterDB;



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
    private void Awake()
    {
        characterDB = GameManager.Instance.GetCharacterData();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimationsSO = characterDB.AnimationSO;
    }

}
