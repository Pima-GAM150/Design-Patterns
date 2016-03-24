using UnityEngine;
using System.Collections;

public class WanderHostile : WanderFriendly {

	public float eatTargetDistance = 2f;
	public float eatInterval = 1f;

	void Start() {
		StartCoroutine( CheckEatenTarget() );
	}

	protected override Vector3 GetPreferredDestination() {
		return closestWanderer != null ? closestWanderer.transform.position : base.GetPreferredDestination();
	}

	IEnumerator CheckEatenTarget() {
		while( enabled ) {

			yield return new WaitForSeconds( Random.Range( 0f, eatInterval ) );

			if( !closestWanderer ) continue;

			if( Vector3.Distance( closestWanderer.transform.position, transform.position ) < eatTargetDistance ) {
				EatWanderer( closestWanderer );
			}
		}
	}

	protected virtual void EatWanderer( WanderBase wanderer ) {
		factory.RemoveWanderer( wanderer );
		agent.SetDestination( GetPreferredDestination() );
	}

	protected override void Reset() {}
}
