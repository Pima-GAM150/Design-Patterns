using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WanderFrightened4 : WanderFrightened3, IWanderObserved {
	
	public UnityEvent destroyedEvent {
		get { return _destroyedEvent; }
	}
	[HideInInspector] public UnityEvent _destroyedEvent;

	public override void OnDisable() {
		destroyedEvent.Invoke();
	}
}
