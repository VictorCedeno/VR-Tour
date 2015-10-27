using UnityEngine;
using System.Collections;



public class MoveCamino1 : MonoBehaviour
{	
	public bool camino1Flag = true;
	void Update(){
		if (camino1Flag){
			iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Camino1"), "easetype", iTween.EaseType.easeInOutSine, "time", 5));
		}

	}
}
