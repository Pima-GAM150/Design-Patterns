using UnityEngine;
using System.Collections;

public class WanderFriendly : WanderBase {

	public float chanceToFollowOtherWanderer = 0.3f;

	protected override void OnTriggerEnter( Collider otherCollider ) {
		base.OnTriggerEnter( otherCollider );

		agent.SetDestination( GetPreferredDestination() );
	}

	protected override Vector3 GetPreferredDestination() {
		Vector3 preferredDestination = base.GetPreferredDestination();
		WanderBase nearestWanderer = closestWanderer;

		if( nearestWanderer && Random.value < chanceToFollowOtherWanderer ) preferredDestination = nearestWanderer.transform.position; 

		return preferredDestination;
	}
}
