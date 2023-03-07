using BossFightGame.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeChecker : MonoBehaviour
{
    [SerializeField] private List<GameObject> Directions;//directional arrows & UI gameobjects located here
    [SerializeField] private List<GameObject> Task;//algorithm derived from directions 
    [SerializeField] private List<string> Result;//player inputs
    private bool isInstantiated;

    [SerializeField] private int difficultyLevel = 4;//replace , for fututre difficulty balancing
    private int checkingIndex = 0;

    private void OnEnable()
    {
        GameEvents.OnSwipingEvent += ResultChecker;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipingEvent -= ResultChecker;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInstantiated == false)
        {
            ShowTask();
        }

    }

    private void ShowTask()
    {
        for (int i = 0; i < difficultyLevel; i++)
        {
            GameObject arrow = Instantiate(Directions[Random.Range(0, Directions.Count)], this.transform);
            Task.Add(arrow);
        }
        isInstantiated = true;
    }

    private void ResultChecker(ActionTypes direction)
    {
        switch (direction)
        {
            case ActionTypes.UP:
                Result.Add(Directions[0].name + "(Clone)");
                break;
            case ActionTypes.RIGHT:
                Result.Add(Directions[1].name + "(Clone)");
                break;
            case ActionTypes.DOWN:
                Result.Add(Directions[2].name + "(Clone)");
                break;
            case ActionTypes.LEFT:
                Result.Add(Directions[3].name + "(Clone)");
                break;
            default:
                break;
        }

        if (Result != null && Task[checkingIndex].name == Result[checkingIndex])
        {

            if (Task.Count!=Result.Count)
            {
                Task[checkingIndex].GetComponent<Image>().color = Color.green;
                checkingIndex++;
            }
            else
            {
                Debug.LogWarning("YOU MADE ACTION!!!");
                Result.Clear();


                //reseting Task list:
                foreach (GameObject arrow in Task)
                {
                    Destroy(arrow);
                }
                Task.Clear();

                ShowTask();
                checkingIndex = 0;
            }
            
        }
        else
        {
            Task[checkingIndex].GetComponent<Image>().color = Color.red;
            Invoke("NewAttempt", 0.5f);
            Debug.Log("Invalid input");
        }
    }

    private void NewAttempt()
    {
        foreach (GameObject item in Task)
        {
            item.GetComponent<Image>().color = Color.white;
        }
        Result.Clear();
        checkingIndex = 0;
    }
}
