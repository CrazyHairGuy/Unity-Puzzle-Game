using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchTrigger : MonoBehaviour {

	public int count = 0;

	void OnTriggerEnter(Collider collider){

		if(collider.CompareTag("excludeFromCrouchTrigger") == false && collider.CompareTag("player_trigger") == false && collider.CompareTag ("ignoreGrabTrigger") == false && collider.CompareTag ("Player") == false)
			count ++;
		//Debug.Log (collider.gameObject.name);
		
	}

	void OnTriggerExit(Collider collider){
		
		if(collider.CompareTag("excludeFromCrouchTrigger") == false && collider.CompareTag("player_trigger") == false && collider.CompareTag ("ignoreGrabTrigger") == false && collider.CompareTag ("Player") == false)
			count -= 1;
	}
		
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
