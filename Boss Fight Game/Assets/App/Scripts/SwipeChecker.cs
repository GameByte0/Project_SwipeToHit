using System.Collections.Generic;
using UnityEngine;

public class SwipeChecker : MonoBehaviour
{
	[SerializeField] private List<GameObject> Directions;
	[SerializeField] private List<GameObject> Task;
	[SerializeField] private List<string> Result;
	private bool isInstantiated;


	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < 4; i++)
		{
			Task.Add(Directions[Random.Range(0, 4)]);
			
		}
	}

	// Update is called once per frame
	void Update()
	{
		ResultChecker();
		if (isInstantiated==false)
		{
			ShowTask();
		}
		
	}

	private void ShowTask()
	{
		foreach (GameObject item in Task)
		{
			Instantiate(item,this.transform);
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
