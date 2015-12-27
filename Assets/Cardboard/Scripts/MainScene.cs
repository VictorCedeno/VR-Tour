using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {

	private CardboardHead head;
	private float delay;
	
	void Start() {
		delay = 0.0f;
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (isLookedAt) {
			GetComponent<Renderer>().material.color = Color.yellow;
		} else {
			GetComponent<Renderer> ().material.color = Color.red; 
			delay = Time.time + 1.5f;
		}
		if (isLookedAt && Time.time>delay) { 
			Application.LoadLevel(0);
			delay = Time.time + 1.5f;
		}
	}

}
