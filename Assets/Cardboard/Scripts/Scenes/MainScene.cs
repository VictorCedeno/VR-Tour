using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {

	private CardboardHead head;
	private float delay;
	
	void Start() {
		delay = 0.0f;
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
		if (isLookedAt) {
			head.BroadcastMessage("looking");
		} else {
			delay = Time.time + 1.5f;
		}
		if (isLookedAt && Time.time>delay) { 
			Application.LoadLevel(Constants.MAIN_SCENE);
			delay = Time.time + 1.5f;
		}
	}

}
