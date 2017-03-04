using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underWater : MonoBehaviour {

	void OnTriggerEnter(Collider collider){

		if (collider.GetComponent<Rigidbody> ())
			collider.GetComponent<Rigidbody> ().drag = 4;

	}

	void OnTriggerExit(Collider collider){

		if (collider.GetComponent<Rigidbody> ())
			collider.GetComponent<Rigidbody> ().drag = 1;

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
