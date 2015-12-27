//Script que regresa al usuario al punto inicial

using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f; 

	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time>delay) { 
			GameObject g = GameObject.FindGameObjectWithTag("Player");
			g.transform.position = new Vector3(0, 1, 0);
			delay = Time.time + 1.0f;
		}
		// currently looking at object
		else if (isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.yellow;
		} 
		// not looking at object
		else if (!isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.red; 
			delay = Time.time + 1.0f; 
		}
		transform.Rotate(Vector3.up, 10 * Time.deltaTime);
	}
	
}