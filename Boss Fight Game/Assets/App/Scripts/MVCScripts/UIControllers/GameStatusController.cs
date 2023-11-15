using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.UIEvents;
using BossFightGame.Events;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameStatusController : MonoBehaviour
{
    [SerializeField] private GameStatusView view;

    private void OnEnable()
    {
        UIEvents.OnGameStatusChangeEvent +=ChangeGameStatus;
    }
    private void OnDisable()
    {
        UIEvents.OnGameStatusChangeEvent -=ChangeGameStatus;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChangeGameStatus(string gameStatus, int statusIndex)
    {
        view.gameObject.SetActive(true);
        view.UpdateGameStatus(gameStatus);
        if (statusIndex == 0)
        {
            StartCoroutine(DeactivateView());
        }
        else
        {
            view.ActivateStateButtons();
        }
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private IEnumerator DeactivateView()
    {
        yield return new WaitForSeconds(1f);
        view.gameObject.SetActive(false);
    } 
}
