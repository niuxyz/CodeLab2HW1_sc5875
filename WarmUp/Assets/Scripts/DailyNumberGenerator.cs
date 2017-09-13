using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyNumberGenerator : NumberGenerator {
	// Use this for initialization
	void Start ()
	 {
		Random.InitState(System.DateTime.Now.DayOfYear);
	}

}
