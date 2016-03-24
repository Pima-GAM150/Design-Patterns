using UnityEngine;
using System.Collections;

public class WanderFrightened2 : WanderFrightened, IClickable {
	
	public void OnClicked( int clickedWithButton ) {
		print( "Clicked on frightened wanderer with mouse button " + clickedWithButton );

		agent.SetDestination( GetPreferredDestination() );
	}
}
