using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatusView : MonoBehaviour
{
    [SerializeField] private PlayerStatusController controller;


    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text playerHealthCount;

    [SerializeField] private Slider manaSlider;
    [SerializeField] private TMP_Text playerManaCount;

    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text playerNameText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetStats(int health, int mana, int level, string name)
    {
        //Health
        healthSlider.maxValue = health;
        healthSlider.value = health;
        playerHealthCount.text = $"{healthSlider.value}";
        //Mana
        manaSlider.maxValue = mana;
        manaSlider.value = mana;
        playerManaCount.text =$"{manaSlider.value}";
        //Level
        levelText.text = "Lvl. " + level;
        //Player Name
        playerNameText.text = name;



    }
    public void ChangeStats(int health, int mana)
    {
        healthSlider.value = health;
        playerHealthCount.text = $"{healthSlider.value}";
        manaSlider.value = mana;
        playerManaCount.text = $"{manaSlider.value}";
    }
}
