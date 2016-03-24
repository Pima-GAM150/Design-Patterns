using UnityEngine;
using System.Collections;

public class WanderFriendly3 : WanderFriendly2 {
	
	public override WandererFactory factory {
		get { return WandererFactorySingleton.instance; }
		set {}
	}
}
