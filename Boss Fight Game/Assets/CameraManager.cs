using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using BossFightGame.UIEvents;
using System;

public class CameraManager : MonoBehaviour
{
    [Header("CAMERAS:")]
    [SerializeField] private CinemachineVirtualCamera mainCam;
    [SerializeField] private CinemachineVirtualCamera characterChangeCam;


    [SerializeField] private List<CinemachineVirtualCamera> allMenuCameras;


    private void OnEnable()
    {
        UIEvents.OnCharacterSelectMenuEvent += OnCharacterSelectMenuEventHandler;
        UIEvents.OnReturnToMainMenuEvent += OnReturnToMainMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnCharacterSelectMenuEvent -= OnCharacterSelectMenuEventHandler;
        UIEvents.OnReturnToMainMenuEvent -= OnReturnToMainMenuEventHandler;
    }

    private void OnCharacterSelectMenuEventHandler()
    {
        SwitchCam(characterChangeCam);
    }
    private void OnReturnToMainMenuEventHandler()
    {
        SwitchCam(mainCam);
    }

    private void Awake()
    {
        allMenuCameras.Add(mainCam);
        allMenuCameras.Add(characterChangeCam);
    }

    private void Start()
    {
        SwitchCam(mainCam);
    }

    private void SwitchCam(CinemachineVirtualCamera c)
    {
        c.Priority = 10;
        foreach (var cam in allMenuCameras)
        {
            if (cam!=c && cam.Priority!=0)
            {
                cam.Priority = 0;
            }
        }
    }
}
