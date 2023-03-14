using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using BossFightGame.UIEvents;
using System;

public class CameraManager : MonoBehaviour
{
    [Header("CAMERAS:")]
    [SerializeField] private CinemachineVirtualCamera portalCam;
    [SerializeField] private CinemachineVirtualCamera characterChangeCam;
    [SerializeField] private CinemachineVirtualCamera settingsWallCam;


    [SerializeField] private List<CinemachineVirtualCamera> allMenuCameras;


    private void OnEnable()
    {
        UIEvents.OnCharacterSelectMenuEvent += OnCharacterSelectMenuEventHandler;
        UIEvents.OnReturnToMainMenuEvent += OnReturnToMainMenuEventHandler;
        UIEvents.OnSettingsMenuEvent += OnSettingsMenuEventHandler;
    }
    private void OnDisable()
    {
        UIEvents.OnCharacterSelectMenuEvent -= OnCharacterSelectMenuEventHandler;
        UIEvents.OnReturnToMainMenuEvent -= OnReturnToMainMenuEventHandler;
        UIEvents.OnSettingsMenuEvent -= OnSettingsMenuEventHandler;
    }

    private void OnCharacterSelectMenuEventHandler()
    {
        SwitchCam(characterChangeCam);
    }
    private void OnReturnToMainMenuEventHandler()
    {
        SwitchCam(portalCam);
    }
    private void OnSettingsMenuEventHandler()
    {
        SwitchCam(settingsWallCam);
    }

    private void Awake()
    {
        allMenuCameras.Add(portalCam);
        allMenuCameras.Add(characterChangeCam);
        allMenuCameras.Add(settingsWallCam);
    }

    private void Start()
    {
        SwitchCam(portalCam);
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
