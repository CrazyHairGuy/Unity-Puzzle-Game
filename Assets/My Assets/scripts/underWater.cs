using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class underWater : MonoBehaviour {

	void OnTriggerEnter(Collider collider){

		//if (collider.GetComponent<GlobalFog>())
		//	collider.gameObject.AddComponent<

		if (collider.GetComponent<Rigidbody> ())
			collider.GetComponent<Rigidbody> ().drag = 4;

	}

	void OnTriggerExit(Collider collider){

		if (collider.GetComponent<Rigidbody> ())
			collider.GetComponent<Rigidbody> ().drag = 0;

	}

	// Use this for initialization
	void Start () {
		RenderSettings.fogColor = new Color(0, 0.25f, 0.35f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
