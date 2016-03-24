using UnityEngine;
using System.Collections;

public class WanderHostile2 : WanderHostile, IClickable, IScrollable {

	public float scrollScaleSpeed = 1f;

	public void OnClicked( int clickedWithButton ) {
		print( "Clicked on hostile wanderer with mouse button " + clickedWithButton );

		agent.SetDestination( GetPreferredDestination() );
	}

	public void OnScrolled( float scrollAmount ) {
		float newLocalScalar = transform.localScale.x + scrollAmount * scrollScaleSpeed;

		transform.localScale = new Vector3( newLocalScalar, newLocalScalar, newLocalScalar );
	}

	public override void OnDisable() {
		base.OnDisable();
		
		transform.localScale = Vector3.one;
	}
}
