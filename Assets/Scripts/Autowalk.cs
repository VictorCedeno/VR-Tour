using UnityEngine;
using System.Collections;

public class Autowalk : MonoBehaviour {
	
	private CardboardHead head;
	private float delay;
	private Move boolBoy;
	private bool moveFlag;
	public int moveSpeed;
	
	void Start() {
		delay = 0.0f;
		moveSpeed = 30;
		moveFlag = false;
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (isLookedAt) {
			head.BroadcastMessage("looking");
		} else {
			delay = Time.time + 1.5f;
		}
		if (isLookedAt && Time.time>delay) { 
			TriggerPulled();
			delay = Time.time + 1.5f;
		}
		if (moveFlag) { 
			GameObject g = GameObject.FindGameObjectWithTag ("Player");
			g.transform.Translate (Camera.main.transform.forward * moveSpeed * Time.deltaTime);
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