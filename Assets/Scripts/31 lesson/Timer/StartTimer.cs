using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] private TimerBar _bar;
    [SerializeField] private float gameTime;

    private void Start()
    {
        StartTheTimer();
    }

    public void StartTheTimer()
    {
        Timer timer = new Timer(this);

        timer.TimerIsOver += FinishGame;
        _bar.Initialize(timer);
        
        timer.Set(gameTime);
        timer.StartCountingTime();

    }

    
    private void FinishGame()
    {
        GameManager.instance.LooseGame();
    }


}
