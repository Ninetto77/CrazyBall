using UnityEngine;

public class InputController : MonoBehaviour
{
    public float startTime = 2f;
    public NumberTask Task;
    
    private float curStartTime;
    private Vector2 start = Vector2.zero;
    private Vector2 end = Vector2.zero;
    private float offset = 0;
    private float dist = 0;
    void Start()
    {
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            switch (Task)
            {
                case NumberTask.Swipe:
                    CheckForStationaryTouch();
                break;
                case NumberTask.Scale:
                    CheckToScale();
                    break;
            }   
        }
    }

    private void CheckForStationaryTouch()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase.Equals(TouchPhase.Began))
        {
            start = touch.position;
            curStartTime = startTime;

        }

        curStartTime -= Time.deltaTime;
        if (curStartTime < 0)
        {
            if ((touch.phase == TouchPhase.Stationary && touch.phase != TouchPhase.Ended) || touch.phase == TouchPhase.Ended)
            {
                end = touch.position;

                if (end.x - start.x >= 100)
                    if (end.y - start.y <= 50)
                    {
                        Debug.Log("Свайп вправо");
                    }
                
                start = touch.position;
                curStartTime = startTime;
            }
        }
    }
    private void CheckToScale()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 secondTouchPos = new Vector2(150, 150);
        Vector2 firstTouchPos = Vector2.zero;

        if (touch.phase.Equals(TouchPhase.Began))
        {
            firstTouchPos = touch.position;
            dist = Vector2.Distance(firstTouchPos, secondTouchPos);
        }


        if (touch.phase == TouchPhase.Moved)
        {
            firstTouchPos = touch.position;
            offset = Vector2.Distance(firstTouchPos, secondTouchPos) - dist;
            if ( dist * 0.1f < offset )
            {
                 Debug.Log("Жест увеличение");
            }
        }
    }
}

public enum NumberTask
{
    Swipe,
    Scale
}