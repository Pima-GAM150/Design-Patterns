using UnityEngine;
using System.Collections;

public class WandererFactoryObserver : WandererFactorySingleton {

	protected override void InitializeWanderer( WanderBase wanderer ) {
		wanderer.gameObject.SetActive( true );
		wanderer.agent.Warp( GetRandomPointOnSurface() );

		IWanderObserved observedInterface = wanderer as IWanderObserved;

		if( observedInterface != null ) {
			observedInterface.destroyedEvent.AddListener( () => RemoveWanderer( wanderer ) );
		}
	}
}
