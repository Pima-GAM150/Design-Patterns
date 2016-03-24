using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour {

	public NavMeshAgent agent;
	[HideInInspector] public Collider floor;
	public float findNewLocationFrequency = 1f;
	
	void Start() {
		agent.Warp( GetRandomPointOnFloor() );

		StartCoroutine( LookForNewDestination() );
	}

	IEnumerator LookForNewDestination() {

		while( this.enabled ) {
			
			agent.SetDestination( GetRandomPointOnFloor() );

			yield return new WaitForSeconds( Random.Range( 0f, findNewLocationFrequency ) );
		}
	}

	Vector3 GetRandomPointOnFloor() {
		float floorWidth = floor.bounds.extents.x;
		float floorBreadth = floor.bounds.extents.z;

		Vector3 randomPosition = new Vector3(Random.Range(-floorWidth, floorWidth), 0f, Random.Range(-floorBreadth, floorBreadth));

		return randomPosition;
	}
}
