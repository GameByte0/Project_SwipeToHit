using BossFightGame.Events;
using UnityEngine;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour
{


    [Header("Swipe Parameters")]
    private Vector2 startTouchPos;

    private Vector2 endTouchPos;

    private bool isSwiped;

    [SerializeField] private int pixelOffset = 50;

    private SwipeDirection swipeDirection;

    //swipe direction order
    private int up = 1;
    private int right = 2;
    private int down = 3;
    private int left = 4;



    void Start()
    {

    }


    void Update()
    {
       


#if UNITY_ANDROID
		//Debug.Log("Android");
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
#endif

#if UNITY_EDITOR
        //Debug.Log("Editor");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            startTouchPos = new Vector2(0, 0);
            endTouchPos = Vector2.up * pixelOffset * 2;
            isSwiped = true;
            DetectDirection();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            startTouchPos = new Vector2(0, 0);
            endTouchPos = Vector2.down * pixelOffset * 2;
            isSwiped = true;
            DetectDirection();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            startTouchPos = new Vector2(0, 0);
            endTouchPos = Vector2.right * pixelOffset * 2;
            isSwiped = true;
            DetectDirection();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            startTouchPos = new Vector2(0, 0);
            endTouchPos = Vector2.left * pixelOffset * 2;
            isSwiped = true;
            DetectDirection();
        }
        else
        {
            startTouchPos = endTouchPos;

        }
#endif

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
                        GameEvents.RaiseOnSwiping(right);
                    }
                    else if (endTouchPos.x < startTouchPos.x + pixelOffset)
                    {
                        Debug.Log("Swipe Left");
                        GameEvents.RaiseOnSwiping(left);
                    }

                    break;

                case SwipeDirection.VERTICAL:
                    //Vertical move detection
                    if (endTouchPos.y > startTouchPos.y + pixelOffset)
                    {
                        Debug.Log("Swipe Up");
                        GameEvents.RaiseOnSwiping(up);
                    }
                    else if (endTouchPos.y < startTouchPos.y + pixelOffset)
                    {
                        Debug.Log("Swipe Down");
                        GameEvents.RaiseOnSwiping(down);
                    }

                    break;

                case SwipeDirection.NONE:
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
    private void PlayAnim(int AnimHash)
    {
        //animator.SetTrigger(AnimHash);
    }
    private enum SwipeDirection
    {
        HORIZONTAL,
        VERTICAL,
        NONE
    }

}
