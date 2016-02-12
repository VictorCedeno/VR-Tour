//Script que regresa al usuario al punto inicial

using UnityEngine;
using System.Collections;

public class GoToClassroom : MonoBehaviour {
	
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
			Toolbox.Instance.scene = Constants.CLASSROOM_PHOTOSPHERE_SCENE;
			Application.LoadLevel (Constants.CLASSROOM_PHOTOSPHERE_SCENE);
			delay = Time.time + 1.0f;
		}
		// currently looking at object
		else if (isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.yellow;
			head.BroadcastMessage("looking");
		} 
		// not looking at object
		else if (!isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.red; 
			delay = Time.time + 1.0f; 
		}
		
	}
	
}