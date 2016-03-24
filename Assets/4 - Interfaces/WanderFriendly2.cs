using UnityEngine;
using System.Collections;

public class WanderFriendly2 : WanderFriendly, IClickable {
	
	public void OnClicked( int clickedWithButton ) {
		print( "Clicked on friendly wanderer with mouse button " + clickedWithButton );

		agent.SetDestination( GetPreferredDestination() );
	}
}
