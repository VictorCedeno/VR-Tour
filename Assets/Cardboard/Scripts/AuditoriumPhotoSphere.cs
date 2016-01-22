﻿using UnityEngine;
using System.Collections;

public class AuditoriumPhotoSphere : MonoBehaviour {

	private CardboardHead head;
	private float delay;
	
	void Start() {
		delay = 0.0f;
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (!isLookedAt) {
			delay = Time.time + 1.5f;
		}
		if (isLookedAt && Time.time>delay) { 
			Application.LoadLevel(1);
			delay = Time.time + 1.5f;
		}
	}
}