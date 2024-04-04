using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 GetInputDeltaPosition()
    {
        if (IsThereTouchOfScreen())
        {
            return Input.GetTouch(0).deltaPosition;
        }
        return Vector2.zero;
    }

    public bool IsThereTouchOfScreen()
    {
        if (Input.touchCount > 0) return true;
        return false;
    }
}
