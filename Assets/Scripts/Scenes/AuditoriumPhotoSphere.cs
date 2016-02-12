﻿using UnityEngine;
using System.Collections;

public class AuditoriumPhotoSphere : MonoBehaviour {

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
		try {
			GetComponentInChildren<Cardboard> ().DevicePause (false);
		} catch {
		}
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (!isLookedAt) {
			delay = Time.time + 1.5f;
		} else {
			head.BroadcastMessage("looking");
		}
		if (isLookedAt && Time.time>delay) { 
			Application.LoadLevel(Constants.AUDITORIUM_PHOTOSPHERE_SCENE);
			delay = Time.time + 1.5f;
		}
	}
}
