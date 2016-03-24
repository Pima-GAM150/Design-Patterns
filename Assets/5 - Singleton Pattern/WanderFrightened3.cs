using UnityEngine;
using System.Collections;

public class WanderFrightened3 : WanderFrightened2 {
	
	public override WandererFactory factory {
		get { return WandererFactorySingleton.instance; }
		set {}
	}
}
