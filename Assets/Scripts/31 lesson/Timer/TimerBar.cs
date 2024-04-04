
public class TimerBar : Bar
{
    public Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        if (_timer != null)
            _timer.HasBeenUpdated += OnValueChanged;
    }

    private void OnDisable()
    {
        if (_timer != null)
            _timer.HasBeenUpdated -= OnValueChanged;
    }
}
