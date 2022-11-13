using UnityEngine;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour
{
	[SerializeField] private Image swipeDirectionImage;

	private Vector2 startTouchPos;

	private Vector2 endTouchPos;

	private bool isSwiped;

	[SerializeField] private int pixelOffset = 50;

	private SwipeDirection swipeDirection;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
		{
			startTouchPos = Input.touches[0].position;
		}
		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
		{
			endTouchPos = Input.touches[0].position;
			isSwiped = true;
			DetectDirection();
		}

		if (isSwiped)
		{
			Debug.Log("Start: " + startTouchPos + " , " + "End: " + endTouchPos);


			switch (swipeDirection)
			{
				case SwipeDirection.HORIZONTAL:
					//Horizontal move detection
					if (endTouchPos.x > startTouchPos.x + pixelOffset)
					{
						Debug.Log("Swipe Right");
					}
					else if (endTouchPos.x < startTouchPos.x + pixelOffset)
					{
						Debug.Log("Swipe Left");

					}

					break;

				case SwipeDirection.VERTICAL:
					//Vertical move detection
					if (endTouchPos.y > startTouchPos.y + pixelOffset)
					{
						Debug.Log("Swipe Up");
					}
					else if (endTouchPos.y < startTouchPos.y + pixelOffset)
					{
						Debug.Log("Swipe Down");
					}

					break;

				case SwipeDirection.NONE :
					Debug.Log("TAP!!!");
					break;
			}


			isSwiped = false;
			startTouchPos = endTouchPos = new Vector2(0, 0);
		}

	}
	private void DetectDirection()
	{
		float X = Mathf.Abs(endTouchPos.x - startTouchPos.x);

		float Y = Mathf.Abs(endTouchPos.y - startTouchPos.y);

		if (X > Y)
		{
			swipeDirection = SwipeDirection.HORIZONTAL;
		}
		else if (X < Y)
		{
			swipeDirection = SwipeDirection.VERTICAL;
		}
		else
		{
			swipeDirection = SwipeDirection.NONE;
		}
	}

	private enum SwipeDirection
	{
		HORIZONTAL,
		VERTICAL,
		NONE
	}

}
