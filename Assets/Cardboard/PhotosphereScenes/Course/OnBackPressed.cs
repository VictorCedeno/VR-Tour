using UnityEngine;
using System.Collections;

public class OnBackPressed : MonoBehaviour {

	private CardboardHead head;
	private float delay = 0.0f;
	
	void LoadScene() {
		Application.LoadLevel(0);
	}
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time>delay) { 
			LoadScene();
			delay = Time.time + 2.0f;
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
