using UnityEngine;
using System.Collections;

public class Toolbox : Singleton<Toolbox> {

	protected Toolbox () {}
	
	public int mode;
	
	void Awake () {
		mode = 0;
	}

}