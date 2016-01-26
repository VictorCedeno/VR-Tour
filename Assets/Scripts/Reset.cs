//Script que regresa al usuario al punto inicial

using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f; 

	/**
	 * 
	 */
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}

	/**
	 * 
	 */
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (!isLookedAt) {
			delay = Time.time + 1.5f;
		} else {
			head.BroadcastMessage("looking");
		}
		if (isLookedAt && Time.time>delay) { 
			Application.LoadLevel(Constants.MAIN_SCENE);
			GameObject g = GameObject.FindGameObjectWithTag("Player");
			g.transform.position = new Vector3(0, 1, 0);
			delay = Time.time + 1.0f;
		}
	}
	
}