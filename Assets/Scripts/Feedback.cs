
using UnityEngine;
using System.Collections;


public class Feedback : MonoBehaviour {
	
	private CardboardHead head;
	private float lastScale;
	
	void Start() {
		reset ();
		lastScale = 0.0f;
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update() {
		if (transform.localScale.y - 0.00015f < lastScale) {
			reset();
		}
		lastScale = transform.localScale.y;
	}
	
	/**
	 * 
	 */
	public void looking() {
		if (Toolbox.Instance.scene == Constants.MAIN_SCENE) {
			scaleY(0.001f);
		} else {
			scaleY(0.05f);
		}
	}
	
	/**
	 * 
	 */
	public void reset() {
		Vector3 scale = transform.localScale;
		scale.y = 0.0f;
		transform.localScale = scale;
	}
	
	/**
	 * 
	 */
	public void scaleY(float f) {
		Vector3 scale = transform.localScale;
		scale.y = transform.localScale.y + f;
		transform.localScale = scale;
	}
	
}
