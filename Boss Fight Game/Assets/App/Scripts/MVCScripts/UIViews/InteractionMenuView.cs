using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionMenuView : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;


    private bool _isViewActive;

    public bool IsViewActive { get => _isViewActive; }
    private void OnEnable()
    {
        _isViewActive = true;
    }
    private void OnDisable()
    {
        _isViewActive = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer(int time)
    {
        timerText.text = time.ToString();
    }
}
