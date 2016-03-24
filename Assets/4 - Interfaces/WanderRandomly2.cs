using UnityEngine;
using System.Collections;

public class WanderRandomly2 : WanderRandomly, IClickable {
	
	public void OnClicked( int clickedWithButton ) {
		print( "Clicked on random wanderer with mouse button " + clickedWithButton );

		agent.SetDestination( GetPreferredDestination() );
	}
}
