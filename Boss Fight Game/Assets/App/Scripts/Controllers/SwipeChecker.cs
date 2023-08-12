using BossFightGame.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BossFightGame.UIEvents;

public class SwipeChecker : MonoBehaviour
{
    [SerializeField] private List<GameObject> Directions;//directional arrows & UI gameobjects located here, never change values in editor!!!
    [SerializeField] private List<GameObject> Task;//algorithm derived from directions 
    [SerializeField] private List<string> Result;//player inputs
    
    private bool isInstantiated;
    private int correctResultCount=0;

    [SerializeField] private int difficultyLevel = 4;//replace , for fututre difficulty balancing
    private int checkingIndex = 0;

    private int _buttonIndex;

    [SerializeField] private Slider swipeTimeSlider;
    private float requiredSwipeTime=2f; //will change depending on difficulty of action
    private float swipeTime = 0;

    public int ButtonIndex { set => _buttonIndex = value; }

    private void OnEnable()
    {
        GameEvents.OnSwipingEvent += ResultChecker;
        swipeTimeSlider.gameObject.SetActive(true);
        swipeTimeSlider.maxValue = requiredSwipeTime;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipingEvent -= ResultChecker;
        ResetChecker();
    }

    // Start is called before the first frame update
    void Start()
    {
        swipeTime = requiredSwipeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (swipeTime>=0)
        {
            swipeTime -= Time.deltaTime;
            swipeTimeSlider.value = swipeTime;

            //Debug.Log(cooldownTime);
        }
        else
        {

            ReturnAccuracy();
        }


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
            Task[checkingIndex].GetComponent<Image>().color = Color.green;
            correctResultCount++;

            if (Task.Count!=Result.Count)
            {
                checkingIndex++;
            }
            else
            {
                Debug.LogWarning("YOU MADE ACTION!!!");
                Result.Clear();     

                checkingIndex = 0;
                ReturnAccuracy();

            }
            
        }
        else
        {
            Task[checkingIndex].GetComponent<Image>().color = Color.red;
            checkingIndex++;
            //Debug.Log("Invalid input");
            if (Task.Count == Result.Count)
            {
                ReturnAccuracy();
            }
        }
    }

    private void ReturnAccuracy()
    {
        float percente = ((float)correctResultCount / (float)Task.Count ) * 100;

        Debug.Log(percente+"%  Correct");
        correctResultCount = 0;

        UIEvents.RaisOnInteractionMenu();
        GameEvents.RaiseOnApplyPercentageEvent(percente,_buttonIndex);
        GameEvents.RaiseOnChangeTurn();


       swipeTime = requiredSwipeTime;

        swipeTimeSlider.gameObject.SetActive(false);
        gameObject.SetActive(false);

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

    private void ResetChecker()
    {
        foreach (GameObject arrow in Task)
        {
            Destroy(arrow);//Reseting Tasks
        }
        Task.Clear();

        Result.Clear();//Reseting Result

        correctResultCount = 0;

        checkingIndex = 0;

        isInstantiated = false;
    }

 
}
