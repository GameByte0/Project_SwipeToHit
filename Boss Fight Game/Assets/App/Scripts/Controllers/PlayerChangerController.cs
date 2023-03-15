using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangerController : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<CharacterDataSO> characterDataBase;

    private int selectedCharacterIndex;

    private GameObject instance;
    private bool isShowing;


    private void Awake()
    {
        selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");
    }
    void Update()
    {
        if (isShowing==false)
        {
            ShowCharacter(selectedCharacterIndex);
        }
    }

    public void NextCharacter()
    {
        if (selectedCharacterIndex!=characterDataBase.Count-1)
        {
            selectedCharacterIndex++;
        }
        else
        {
            selectedCharacterIndex = 0;
        }
        isShowing = false;
    }
    public void PreviousCharacter()
    {
        if (selectedCharacterIndex!=0)
        {
            selectedCharacterIndex--;
        }
        else
        {
            selectedCharacterIndex = characterDataBase.Count - 1;
        }
        isShowing = false;
    }
    private void ShowCharacter(int index)
    {
        if (instance!=null)
        {
            Destroy(instance);
        }
       instance = Instantiate(characterDataBase[index].CharacterPrefab, spawnPoint);
        isShowing = true;
    }



}
