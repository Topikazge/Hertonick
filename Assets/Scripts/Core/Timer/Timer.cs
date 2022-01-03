using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
	private TimerInvoker _timerInvoker;

	public Timer(TimerType type)
	{
		this.type = type;
	}

	public Timer(TimerType type, float seconds)
	{
		this.type = type;

		SetTime(seconds);
	}

	public TimerType type { get; }
	public bool isActive { get; private set; }
	public bool isPaused { get; private set; }
	public float remainingSeconds { get; private set; }

	public event Action<float> OnTimerValueChangedEvent;
	public event Action OnTimerFinishedEvent;

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

		if (System.Math.Abs(remainingSeconds) < Mathf.Epsilon)
		{
#if DEBUG
			Debug.LogError("TIMER: You are trying start timer with remaining seconds equal 0.");
#endif
			OnTimerFinishedEvent?.Invoke();
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

		OnTimerValueChangedEvent?.Invoke(remainingSeconds);
		OnTimerFinishedEvent?.Invoke();
	}


	private void SubscribeOnTimeInvokerEvents()
	{
		switch (type)
		{
			case TimerType.UpdateTick:
				_timerInvoker.OnUpdateTimeTickedEvent += OnTicked;
				break;
			case TimerType.UpdateTickUnscaled:
				_timerInvoker.OnUpdateTimeUnscaledTickedEvent += OnTicked;
				break;
			case TimerType.OneSecTick:
				_timerInvoker.OnOneSyncedSecondTickedEvent += OnSyncedSecondTicked;
				break;
			case TimerType.OneSecTickUnscaled:
				_timerInvoker.OnOneSyncedSecondUnscaledTickedEvent += OnSyncedSecondTicked;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void UnsubscribeFromTimeInvokerEvents()
	{
		switch (type)
		{
			case TimerType.UpdateTick:
				_timerInvoker.OnUpdateTimeTickedEvent -= OnTicked;
				break;
			case TimerType.UpdateTickUnscaled:
				_timerInvoker.OnUpdateTimeUnscaledTickedEvent -= OnTicked;
				break;
			case TimerType.OneSecTick:
				_timerInvoker.OnOneSyncedSecondTickedEvent -= OnSyncedSecondTicked;
				break;
			case TimerType.OneSecTickUnscaled:
				_timerInvoker.OnOneSyncedSecondUnscaledTickedEvent -= OnSyncedSecondTicked;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void CheckFinish()
	{
		if (remainingSeconds <= 0f)
			Stop();
		else
			OnTimerValueChangedEvent?.Invoke(remainingSeconds);
	}


	#region CALLBACKS

	private void OnTicked(float deltaTime)
	{
		remainingSeconds -= deltaTime;
		CheckFinish();
	}

	private void OnSyncedSecondTicked()
	{
		remainingSeconds -= 1;
		CheckFinish();
	}

	#endregion
}
