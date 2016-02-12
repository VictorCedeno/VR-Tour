using UnityEngine;
using System.Collections;

public class Toolbox : Singleton<Toolbox> {

	protected Toolbox () {}
	
	public int mode;
	public int scene;
	
	void Awake () {
		mode = 0;
		scene = 0;
	}

}