using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WanderHostile4 : WanderHostile3, IWanderObserved {

	public UnityEvent destroyedEvent {
		get { return _destroyedEvent; }
	}
	[HideInInspector] public UnityEvent _destroyedEvent;

	protected override void EatWanderer( WanderBase wanderer ) {
		IWanderObserved observedWanderer = wanderer as IWanderObserved;
		if( observedWanderer != null ) observedWanderer.destroyedEvent.Invoke();

		agent.SetDestination( GetPreferredDestination() );
	}
}
