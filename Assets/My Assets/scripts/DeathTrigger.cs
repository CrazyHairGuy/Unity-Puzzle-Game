using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class DeathTrigger : death {

	void OnTriggerEnter(Collider collider){

		if (collider.CompareTag ("Player")) {
			
			death.Instance.Die (collider.gameObject);

		}

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
