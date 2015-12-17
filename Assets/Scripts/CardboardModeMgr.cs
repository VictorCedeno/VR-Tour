using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardboardModeMgr : MonoBehaviour {
	
	// We need a reference to camera which 
	// is how we get to the cardboard components.
	public GameObject mainCamera;
	
	
	public void Start()
	{
		// Save a flag in the local player preferences to initialize VR mode
		// This way when the app is restarted, it is in the mode that was last used.
		int doVR = PlayerPrefs.GetInt("VREnabled");
		Cardboard.SDK.VRModeEnabled = doVR == 1;
		CardboardHead head = mainCamera.GetComponent<CardboardHead>();
		head.enabled  = Cardboard.SDK.VRModeEnabled;
		Cardboard.SDK.TapIsTrigger = true;
	}
	
	// The event handler to call to toggle Cardboard mode.
	public void ChangeCardboardMode ()
	{
		CardboardHead head = mainCamera.GetComponent<CardboardHead>();
		if (Cardboard.SDK.VRModeEnabled) {
			// disabling.  rotate back to the original rotation.
			head.transform.localRotation = Quaternion.identity;
		}
		Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
		head.enabled  = Cardboard.SDK.VRModeEnabled;
		PlayerPrefs.SetInt("VREnabled", Cardboard.SDK.VRModeEnabled?1:0);
		PlayerPrefs.Save();        
	}
}