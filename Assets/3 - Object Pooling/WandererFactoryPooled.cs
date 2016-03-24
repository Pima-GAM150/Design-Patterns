using UnityEngine;
using System.Collections;

public class WandererFactoryPooled : WandererFactory {

	public float birthInterval = 1f;

	protected override void Start() {
		base.Start();

		StartCoroutine( RandomlySpawnWanderers() );
	}

	public override void AddWanderer( WanderBase wandererToAdd ) {

		foreach( WanderBase wanderer in wandererInstances ) {
			if( wanderer.GetType() == wandererToAdd.GetType() ) {
				if( wanderer.gameObject.activeInHierarchy == false ) {
					InitializeWanderer( wanderer );

					return;
				}
			}
		}

		base.AddWanderer( wandererToAdd );
	}

	public override void RemoveWanderer( WanderBase wandererToRemove ) {
		wandererToRemove.gameObject.SetActive( false );
	}

	IEnumerator RandomlySpawnWanderers() {
		while( enabled ) {
			SpawnWanderers( 1 );

			yield return new WaitForSeconds( birthInterval );
		}
	}
}
