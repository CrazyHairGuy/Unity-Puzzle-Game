using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisable : MonoBehaviour {

	int count = 0;
	public Material alpha;
	public Material original;

	void OnTriggerEnter(Collider collider){

		if (collider.CompareTag ("excludefromcamera") == false) {

			collider.GetComponent<Material>().name = alpha.name;

		}

	}

	void OnTriggerExit(Collider collider){

		if (collider.CompareTag ("excludefromcamera") == false) {

			collider.GetComponent<Material>().name = original.name;

		}

	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
