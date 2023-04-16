using BossFightGame.Events;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.GameManager;

public class PlayerChangerController : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private int selectedCharacterIndex;

    private GameObject instance;
    private bool isShowing;
    private bool isCharacterSelected;

    private void Awake()
    {
        selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");
    }
    void Update()
    {
        if (isShowing == false)
        {
            ShowCharacter(selectedCharacterIndex);
        }
    }

    public void NextCharacter()
    {
        if (selectedCharacterIndex != GameManager.Instance.CharacterDataBase.Count - 1)
        {
            
            selectedCharacterIndex++;
        }
        else
        {
            selectedCharacterIndex = 0;
        }
        isCharacterSelected = false;
        isShowing = false;
    }
    public void PreviousCharacter()
    {
        if (selectedCharacterIndex != 0)
        {
            selectedCharacterIndex--;
        }
        else
        {
            selectedCharacterIndex = GameManager.Instance.CharacterDataBase.Count - 1;
        }
        isCharacterSelected = false;
        isShowing = false;
    }
    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedCharacterIndex);


        int i = PlayerPrefs.GetInt("SelectedCharacterIndex");
        Debug.Log("Selected Character : " + selectedCharacterIndex + "Saved Index : " + i);
        
        isCharacterSelected = true;
        isShowing = false;

    }
    private void ShowCharacter(int index)
    {
        int i = PlayerPrefs.GetInt("SelectedCharacterIndex");
        if (isCharacterSelected==false)
        {
            if (instance != null)
            {
                Destroy(instance);
            }
            instance = Instantiate(GameManager.Instance.CharacterDataBase[index].CharacterPrefab, spawnPoint);
            isShowing = true;
            
            //simple debug for checking algorithm
            Debug.Log("Current Character : " + selectedCharacterIndex + "Saved Index : " + i);

        }
        //if showing character already selected don't show "Select" button
        GameEvents.RaiseOnSelectingFighter(selectedCharacterIndex == i);

    }



}
