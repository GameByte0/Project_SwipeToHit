using System.Collections.Generic;
using UnityEngine;
using BossFightGame.Events;

public class SwipeChecker : MonoBehaviour
{
    [SerializeField] private List<GameObject> Directions;
    [SerializeField] private List<GameObject> Task;
    [SerializeField] private List<string> Result;
    private bool isInstantiated;

    private void OnEnable()
    {
        GameEvents.OnSwipingEvent += OnSwipingEventHandler;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipingEvent -= OnSwipingEventHandler;
    }

    private void OnSwipingEventHandler(int a)
    {
        Debug.Log(a);
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ResultChecker();
        if (isInstantiated == false)
        {
            ShowTask();
        }

    }

    private void ShowTask()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(Directions[Random.Range(0, 4)], this.transform);
        }
        isInstantiated = true;
    }

    private void ResultChecker()
    {

        for (int i = 0; i < Result.Count; i++)
        {

        }
    }
}
