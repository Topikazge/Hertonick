using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerInvoker : MonoBehaviour
{
	public event Action<float> OnUpdateTimeTickedEvent;
	public event Action<float> OnUpdateTimeUnscaledTickedEvent;

	private void Update()
	{
		var deltaTimer = Time.deltaTime;
		OnUpdateTimeTickedEvent?.Invoke(deltaTimer);

		var unscaledDeltaTimer = Time.unscaledDeltaTime;
		OnUpdateTimeUnscaledTickedEvent?.Invoke(Time.unscaledDeltaTime);
	}
}
