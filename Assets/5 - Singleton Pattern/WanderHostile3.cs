using UnityEngine;
using System.Collections;

public class WanderHostile3 : WanderHostile2 {

	public override WandererFactory factory {
		get { return WandererFactorySingleton.instance; }
		set {}
	}
}
