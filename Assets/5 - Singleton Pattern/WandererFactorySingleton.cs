using UnityEngine;
using System.Collections;

public class WandererFactorySingleton : WandererFactoryPooled {

	public static WandererFactorySingleton instance;

	void Awake() {
		instance = this;
	}

	protected override void InitializeWanderer( WanderBase wanderer ) {
		wanderer.gameObject.SetActive( true );
		// wanderer.factory = this;
		wanderer.agent.Warp( GetRandomPointOnSurface() );
	}
}
