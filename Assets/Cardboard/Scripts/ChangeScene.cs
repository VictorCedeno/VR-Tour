using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	private CardboardHead head;
	private float delay = 0.0f;

	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		if (Toolbox.Instance.mode == Constants.VR_MODE) {
			Cardboard.SDK.VRModeEnabled = true;
		} else {
			Cardboard.SDK.VRModeEnabled = false;
		}
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time>delay) { 
			delay = Time.time + 2.0f;
			Application.LoadLevel(Constants.CLASSROOM_SCENE);
		}
		// currently looking at object
		else if (isLookedAt) { 
			head.BroadcastMessage("looking");
		} 
		// not looking at object
		else if (!isLookedAt) { 
			delay = Time.time + 2.0f; 
		}
	}
}
