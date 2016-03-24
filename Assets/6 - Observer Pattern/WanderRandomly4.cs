using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WanderRandomly4 : WanderRandomly3, IWanderObserved {
	
	public UnityEvent destroyedEvent {
		get { return _destroyedEvent; }
	}
	[HideInInspector] public UnityEvent _destroyedEvent;

	public override void OnDisable() {
		destroyedEvent.Invoke();
	}
}
