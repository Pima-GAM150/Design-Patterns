using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public interface IWanderObserved {
	UnityEvent destroyedEvent { get; }

	void OnDisable();
}
