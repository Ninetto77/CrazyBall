using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action<float> HasBeenUpdated;
    public event Action TimerIsOver;

    private float _time;
    private float _remainigTime;

    private IEnumerator _countDown;
    private MonoBehaviour _context;

    public Timer(MonoBehaviour context) => _context = context;

    public void Set(float time)
    {
        _time = time;
        _remainigTime = _time;
    }
    
    public void StartCountingTime()
    {
        _countDown = CountDown();
        _context.StartCoroutine(_countDown);
    }

    public void StopCountingTime()
    {
        if (_countDown != null)
        {
            _context.StopCoroutine(_countDown);
        }
    }

    private IEnumerator CountDown()
    {
        while(_remainigTime >= 0)
        {
            _remainigTime -= Time.deltaTime;
            HasBeenUpdated?.Invoke(_remainigTime / _time);

            yield return null;
        }

        TimerIsOver?.Invoke();
    }

}
