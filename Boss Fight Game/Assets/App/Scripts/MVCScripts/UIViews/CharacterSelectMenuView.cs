using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectMenuView : MonoBehaviour
{
    [SerializeField] private Button selectButton ;
    [SerializeField] private TMP_Text selectText;

    private string enabledSelect = "Select";
    private string disabledSelect = "Selected";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void DisableCharacterSelection()
    {
        selectText.text = disabledSelect;
        selectButton.interactable = false;
    }
    public void EnableCharacterSelection()
    {
        selectText.text = enabledSelect;
        selectButton.interactable = true;
    }
}
