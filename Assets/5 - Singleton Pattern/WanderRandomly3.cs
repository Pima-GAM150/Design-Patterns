using UnityEngine;
using System.Collections;

public class WanderRandomly3 : WanderRandomly2 {
	
	public override WandererFactory factory {
		get { return WandererFactorySingleton.instance; }
		set {}
	}
}
