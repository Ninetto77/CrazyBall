using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Window : MonoBehaviour
{
    public enum WindowStatesRead
    {
        Opened,
        Closed,
    }
    public enum WindowStatesAwake
    {
        Open,
        Close
    }

    [SerializeField]
    public WindowStatesAwake stateOnAwake = WindowStatesAwake.Close;
    [SerializeField]
    public WindowStatesRead CurrentWindowState = WindowStatesRead.Opened;
    protected CanvasGroup m_canvasGroup
    {
        get
        {
            if (!_canvasGroup)
                _canvasGroup = GetComponent<CanvasGroup>();
            return _canvasGroup;
        }
    }
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        Initialization();
    }

    protected virtual void Initialization()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        switch (stateOnAwake)
        {
            case WindowStatesAwake.Close:
                Close_Instantly();
                break;

            case WindowStatesAwake.Open:
                Open_Instantly();
                break;
        }
    }

    public void SwitchState()
    {
        if (CurrentWindowState == WindowStatesRead.Opened)
        {
            Close_Instantly();
        }
        else
        {
            Open_Instantly();
        }
    }

    public void Open_Instantly()
    {
        m_canvasGroup.alpha = 1f;
        m_canvasGroup.blocksRaycasts = true;
        m_canvasGroup.interactable = true;

        CurrentWindowState = WindowStatesRead.Opened;
    }

    public void Close_Instantly()
    {
        m_canvasGroup.alpha = 0f;
        m_canvasGroup.blocksRaycasts = false;
        m_canvasGroup.interactable = false;

        CurrentWindowState = WindowStatesRead.Closed;
    }
}
