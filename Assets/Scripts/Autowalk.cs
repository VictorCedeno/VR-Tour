using UnityEngine;
using System.Collections;

public class Autowalk : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f; 

	public MoveCamino1 boolBoy;
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time>delay) { 
			GameObject g = GameObject.FindGameObjectWithTag ("Player");
			boolBoy = g.GetComponent<MoveCamino1> ();
			// accesses the bool named "isOnFire" and changed it's value.
			boolBoy.camino1Flag= !boolBoy.camino1Flag;
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
	}
	
}