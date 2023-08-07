using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatusView : MonoBehaviour
{
    [SerializeField] private GameStatusController controller;

    [SerializeField] private TMP_Text gameStatusText;
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
}
