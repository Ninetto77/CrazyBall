using UnityEngine;

public class BarButton : MonoBehaviour
{
    [SerializeField] private GameObject[] States;
    public enum StateBar
    {
        on, 
        off
    }

    private void Awake()
    {
        StartSettings startSettings = new StartSettings(this);
    }

    public void ChangeState(StateBar state)
    {
        switch (state)
        {
            case StateBar.on:
                States[0].SetActive(true);
                States[1].SetActive(false);
                break;
            case StateBar.off:
                States[0].SetActive(false);
                States[1].SetActive(true);
                break;
        }
    }
}
