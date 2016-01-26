using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public GameObject mainContainer;
	public GameObject startContainer;
	public GameObject instructionsContainer;

	/**
	 * 
	 */
	void Start () {
		mainContainer = GameObject.Find ("MainContainer");
		startContainer = GameObject.Find ("StartContainer");
		instructionsContainer = GameObject.Find ("InstructionsContainer");

		startContainer.SetActive (false);
		instructionsContainer.SetActive (false);
	}

	/**
	 * 
	 */
	public void StartContainer () {
		mainContainer.SetActive (false);
		startContainer.SetActive (true);
		instructionsContainer.SetActive (false);
	}

	/**
	 * 
	 */
	public void InstructionsContainer() {
		mainContainer.SetActive (false);
		startContainer.SetActive (false);
		instructionsContainer.SetActive (true);
	}

	/**
	 * 
	 */
	public void OnBackPressed() {
		mainContainer.SetActive (true);
		startContainer.SetActive (false);
		instructionsContainer.SetActive (false);
	}

	/**
	 * 
	 */
	public void StandardMode() {
		Toolbox.Instance.mode = Constants.STANDARD_MODE;
		Application.LoadLevel (Constants.MAIN_SCENE);
	}

	/**
	 * 
	 */
	public void VRMode() {
		Toolbox.Instance.mode = Constants.VR_MODE;
		Application.LoadLevel (Constants.MAIN_SCENE);
	}

}
