using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyStatusView : MonoBehaviour
{
    [SerializeField] private EnemyStatusController controlller;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider manaSlider;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text enemyNameText;
    [SerializeField] private TMP_Text enemyHealthCount;
    [SerializeField] private TMP_Text enemyManaCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetStats(int health, int mana, string name)
    {
        int level = Random.Range(1, 2);

        healthSlider.maxValue = health;
        healthSlider.value = health;
        enemyHealthCount.text = healthSlider.value + "/" + healthSlider.maxValue;

        manaSlider.maxValue = mana;
        manaSlider.value = mana;
        enemyManaCount.text = manaSlider.value + "/" + manaSlider.maxValue;


        levelText.text = "Lvl. " + level ;

        enemyNameText.text = name;
    }
}
