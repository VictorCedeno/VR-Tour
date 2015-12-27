using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public bool moveFlag = false;
	public int movespeed = 10;

	void Update() {
		if (moveFlag) {
			GameObject g = GameObject.FindGameObjectWithTag ("Player");
			g.transform.Translate (Camera.main.transform.forward * movespeed * Time.deltaTime);
		}
		if (Input.GetKeyDown ("space")) {
			moveFlag = !moveFlag;
		}
	}

	void OnEnable(){
		Cardboard.SDK.OnTrigger += TriggerPulled;
	}
	
	void OnDisable(){
		Cardboard.SDK.OnTrigger -= TriggerPulled;
	}
	
	void TriggerPulled() {
		moveFlag = !moveFlag;	
	}

}


