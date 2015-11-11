using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public bool moveFlag = false;
	public int movespeed = 5;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		// ...
		if (moveFlag) {
			GameObject g = GameObject.FindGameObjectWithTag ("Player");
			//g.transform.position += Camera.main.transform.forward * 2 * Time.deltaTime; // or transform.position, both would work
			g.transform.Translate (Camera.main.transform.forward * movespeed * Time.deltaTime);
		}

		// ...
	}
}
