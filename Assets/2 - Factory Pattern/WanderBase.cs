using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class WanderBase : MonoBehaviour {

	public NavMeshAgent agent;
	public float findNewDestinationFrequency = 1f;
	public float chanceToSpawn = 0.5f;

	protected Vector3 currentDest;
	float runningTimer = 0f;

	protected List<WanderBase> nearbyWanderers = new List<WanderBase>();

	protected virtual void Update() {

		if( runningTimer == 0f ) agent.SetDestination( GetPreferredDestination() );
		runningTimer += Time.deltaTime;

		if( runningTimer > findNewDestinationFrequency ) runningTimer = 0f;
	}

	protected virtual Vector3 GetPreferredDestination() {
		return factory.GetRandomPointOnSurface();
	}

	protected virtual void Reset() {}

	protected virtual void OnTriggerEnter( Collider otherCollider ) {
		WanderBase otherWanderer = otherCollider.GetComponent<WanderBase>();
		if( otherWanderer ) nearbyWanderers.Add( otherWanderer );
	}

	protected virtual void OnTriggerExit( Collider otherCollider ) {
		for( int index = 0; index < nearbyWanderers.Count; index++ ) {
			if( otherCollider.gameObject == nearbyWanderers[index].gameObject ) {
				nearbyWanderers.RemoveAt( index );
				break;
			}
		}
	}

	public virtual void OnDisable() {
		factory.RemoveWanderer( this );
	}

	public virtual WandererFactory factory {
		get { return _factory; }
		set { _factory = value; }
	}
	WandererFactory _factory;

	protected WanderBase closestWanderer {
		get {
			WanderBase closest = null;
			float closestDistance = Mathf.Infinity;
			foreach( WanderBase nearbyWanderer in nearbyWanderers ) {
				if( !nearbyWanderer.gameObject.activeInHierarchy ) continue;

				float distToThisWanderer = Vector3.Distance( transform.position, nearbyWanderer.transform.position );
				if( distToThisWanderer < closestDistance ) {
					closestDistance = distToThisWanderer;
					closest = nearbyWanderer;
				}
			}

			return closest;
		}
	}
}
