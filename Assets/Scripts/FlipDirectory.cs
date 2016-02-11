//Sciprt del destino # 1

using UnityEngine;
using System.Collections;

public class FlipDirectory : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f;  
	
	private GameObject Signs1;
	private GameObject Signs2;
	private GameObject Signs3;
	private GameObject Signs4;
	int flip = 0;

	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
		Signs1 = GameObject.Find("PrimerSegundoPiso");
		Signs2 = GameObject.Find("Lobby");
		Signs3 = GameObject.Find("Profesores1");
		Signs4 = GameObject.Find("Profesores2");
		
		Signs2.SetActive(false);
		Signs3.SetActive(false);
		Signs4.SetActive(false);
		
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time>delay) { 
			if(flip==0)
			{
				Signs1.SetActive(false);
				Signs2.SetActive(true);
				Signs3.SetActive(false);
				Signs4.SetActive(false);
			}
			if(flip==1)
			{
				Signs1.SetActive(false);
				Signs2.SetActive(false);
				Signs3.SetActive(true);
				Signs4.SetActive(false);
			}
			if(flip==2)
			{
				Signs1.SetActive(false);
				Signs2.SetActive(false);
				Signs3.SetActive(false);
				Signs4.SetActive(true);
			}
			if(flip==3)
			{
				Signs1.SetActive(true);
				Signs2.SetActive(false);
				Signs3.SetActive(false);
				Signs4.SetActive(false);
			}

			delay = Time.time + 1.0f;
			flip++;
			if (flip>3)
				flip=0;
		}
		// currently looking at object
		else if (isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.yellow;
			head.BroadcastMessage("looking");
		} 
		// not looking at object
		else if (!isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.green; 
			delay = Time.time + 1.0f; 
		}
	}
	
	
}