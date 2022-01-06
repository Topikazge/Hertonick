using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer
{
    private TimerInvoker _timerInvoker;
    private float _time;

    public Timer(float seconds)
    {
        SetTime(seconds);
    }

    public bool isActive { get; private set; }
    public bool isPaused { get; private set; }
    public float remainingSeconds { get; private set; }
    

    public event Action<float> OnTimerValueChangedEvent;
    public event Action<float> OnTimerFinishedEvent;

    public void SetTime(float seconds)
    {
        _timerInvoker = GameObject.FindObjectOfType<TimerInvoker>();
        remainingSeconds = seconds;
        OnTimerValueChangedEvent?.Invoke(remainingSeconds);
    }

    public void Start()
    {
        if (isActive)
            return;

        if (Math.Abs(remainingSeconds) < Mathf.Epsilon)
        {
#if DEBUG
            Debug.LogError("TIMER: You are trying start timer with remaining seconds equal 0.");
#endif
            OnTimerFinishedEvent?.Invoke(_time);
        }

        isActive = true;
        isPaused = false;
        SubscribeOnTimeInvokerEvents();

        OnTimerValueChangedEvent?.Invoke(remainingSeconds);
    }

    public void Start(float seconds)
    {
        if (isActive)
            return;

        SetTime(seconds);
        Start();
    }

    public void Pause()
    {
        if (isPaused || !isActive)
            return;

        isPaused = true;
        UnsubscribeFromTimeInvokerEvents();

        OnTimerValueChangedEvent?.Invoke(remainingSeconds);
    }

    public void Unpause()
    {
        if (!isPaused || !isActive)
            return;

        isPaused = false;
        SubscribeOnTimeInvokerEvents();

        OnTimerValueChangedEvent?.Invoke(remainingSeconds);
    }

    public void Stop()
    {
        if (!isActive)
            return;

        UnsubscribeFromTimeInvokerEvents();
        remainingSeconds = 0f;
        isActive = false;
        isPaused = false;

     //   OnTimerValueChangedEvent?.Invoke(remainingSeconds);
        OnTimerFinishedEvent?.Invoke(_time);
        _time = 0f;
    }


    public float GetCurrentTime()
    {
        return _time;
    }

    private void SubscribeOnTimeInvokerEvents()
    {
        _timerInvoker.OnUpdateTimeTickedEvent += OnTicked;
        _timerInvoker.OnUpdateTimeUnscaledTickedEvent += OnTicked;

    }

    private void UnsubscribeFromTimeInvokerEvents()
    {
        _timerInvoker.OnUpdateTimeTickedEvent -= OnTicked;
        _timerInvoker.OnUpdateTimeUnscaledTickedEvent -= OnTicked;
    }

    private void CheckFinish()
    {
        if (_time >= remainingSeconds)
            Stop();
        else
            OnTimerValueChangedEvent?.Invoke(_time);
    }


    private void OnTicked(float deltaTime)
    {
        _time += deltaTime;
        //    remainingSeconds -= deltaTime;
        CheckFinish();
    }


}
