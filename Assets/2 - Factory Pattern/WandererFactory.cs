using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WandererFactory : MonoBehaviour {

	public Collider floor;
	public List<WanderBase> wandererPrefabs = new List<WanderBase>();
	public int numWanderersToCreate = 10;

	[HideInInspector] public List<WanderBase> wandererInstances = new List<WanderBase>();

	protected virtual void Start() {
		SpawnWanderers( numWanderersToCreate );
	}

	public virtual void AddWanderer( WanderBase wandererToAdd ) {
		WanderBase newWanderer = Instantiate<WanderBase>( wandererToAdd );
		wandererInstances.Add( newWanderer );

		InitializeWanderer( newWanderer );
	}

	public virtual void RemoveWanderer( WanderBase wandererToRemove ) {
		wandererInstances.Remove( wandererToRemove );

		Destroy( wandererToRemove.gameObject );
	}

	protected virtual void InitializeWanderer( WanderBase wanderer ) {
		wanderer.gameObject.SetActive( true );
		wanderer.factory = this;
		wanderer.agent.Warp( GetRandomPointOnSurface() );
	}

	public Vector3 GetRandomPointOnSurface() {
		float floorWidth = floor.bounds.extents.x;
		float floorBreadth = floor.bounds.extents.z;

		Vector3 randomPosition = new Vector3(Random.Range(-floorWidth, floorWidth), 0f, Random.Range(-floorBreadth, floorBreadth));

		return randomPosition;
	}

	protected void SpawnWanderers( int numWanderers ) {
		int numWanderersCreated = 0;
		while( numWanderersCreated < numWanderers ) {
			WanderBase wandererCandidate = wandererPrefabs[ Random.Range( 0, wandererPrefabs.Count ) ];
			if( wandererCandidate.chanceToSpawn == 0f ) continue;
			
			if( Random.value < wandererCandidate.chanceToSpawn ) {
				AddWanderer( wandererCandidate );
				numWanderersCreated++;
			}
		}
	}
}
