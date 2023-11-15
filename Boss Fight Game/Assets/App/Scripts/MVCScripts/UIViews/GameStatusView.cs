using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameStatusView : MonoBehaviour
{
    [SerializeField] private GameStatusController controller;

    [SerializeField] private TMP_Text gameStatusText;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _restartButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateGameStatus(string statusText)
    {
        gameStatusText.text = statusText;
    }
    public void ActivateStateButtons()
    {
        _mainMenuButton.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
    }
}
