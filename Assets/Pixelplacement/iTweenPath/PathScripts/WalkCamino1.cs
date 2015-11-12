﻿//Sciprt del destino # 1

using UnityEngine;
using System.Collections;

public class WalkCamino1 : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f; 

	public bool camino1Flag = false;

	void MoveFunction(){
		GameObject g = GameObject.FindGameObjectWithTag ("Player");
		iTween.MoveTo(g, iTween.Hash("path", iTweenPath.GetPath("Camino1"), "easetype", iTween.EaseType.easeOutSine, "time", 5));
	}
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time>delay) { 
			if(camino1Flag = true)
			{
				MoveFunction();
			}
			delay = Time.time + 2.0f;
		}
		// currently looking at object
		else if (isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.yellow; 
		} 
		// not looking at object
		else if (!isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.green; 
			delay = Time.time + 2.0f; 
		}
	}

	
}