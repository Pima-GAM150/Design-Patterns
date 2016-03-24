using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WanderFriendly4 : WanderFriendly3, IWanderObserved {
	
	public UnityEvent destroyedEvent {
		get { return _destroyedEvent; }
	}
	[HideInInspector] public UnityEvent _destroyedEvent;

	public override void OnDisable() {
		destroyedEvent.Invoke();
	}
}
