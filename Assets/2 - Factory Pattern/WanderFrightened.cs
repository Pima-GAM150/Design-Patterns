using UnityEngine;
using System.Collections;

public class WanderFrightened : WanderBase {

	public float frightenedRange = 20f;
	public float notSafeRange = 5f;

	protected override Vector3 GetPreferredDestination() {

		foreach( WanderBase nearbyWanderer in nearbyWanderers ) {
			if( nearbyWanderer is WanderHostile ) return GetFarthestPointFrom( nearbyWanderer.transform.position );
		}

		return closestWanderer != null ? closestWanderer.transform.position : base.GetPreferredDestination();
	}

	protected override void OnTriggerEnter( Collider otherCollider ) {
		base.OnTriggerEnter( otherCollider );

		agent.SetDestination( GetPreferredDestination() );
	}

	Vector3 GetFarthestPointFrom( Vector3 pos ) {
		Vector3 dirFromTarget = (transform.position - pos).normalized;
		float longRange = 99999f;

		Vector3 farPoint = transform.position + dirFromTarget * longRange;
		Vector3 farthestPoint = factory.floor.ClosestPointOnBounds( farPoint );

		if( Vector3.Distance( transform.position, farthestPoint ) < notSafeRange ) {
			dirFromTarget = (pos - transform.position).normalized;
			farPoint = transform.position + dirFromTarget * longRange;
			farthestPoint = factory.floor.ClosestPointOnBounds( farPoint );
		}
		return farthestPoint;
	}
}
