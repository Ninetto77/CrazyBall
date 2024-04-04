using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private InputHandler InputHandl;
    [SerializeField] private float SpeedBall;
    void Start()
    {
        InputHandl = GetComponent<InputHandler>();
    }

    void Update()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        if (InputHandl.IsThereTouchOfScreen())
        {
            Vector2 curDelPos = InputHandl.GetInputDeltaPosition();
            curDelPos *= SpeedBall;
            Vector3 newGravityVec = new Vector3(curDelPos.x, Physics.gravity.y, curDelPos.y);
            Physics.gravity = newGravityVec;
        }
    }
}
