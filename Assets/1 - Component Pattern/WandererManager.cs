using UnityEngine;
using System.Collections;

public class WandererManager : MonoBehaviour {

	public Collider floor;
	public Wander wandererPrefab;
	public int numWanderersToCreate = 1;

	void Start() {
		for( int index = 0; index < numWanderersToCreate; index++ ) {
			Wander wanderer = Instantiate<Wander>( wandererPrefab );
			wanderer.floor = this.floor;
		}
	}
}
