using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class underWater : MonoBehaviour {

	void OnTriggerEnter(Collider collider){

		//if (collider.GetComponent<GlobalFog>())
		//	collider.gameObject.AddComponent<

		if (collider.GetComponent<Rigidbody> ()) {
			collider.GetComponent<Rigidbody> ().drag = 4;
		}
	}

	void OnTriggerStay(Collider collider){

		int bigger = 1;

		if (collider.GetComponent<Rigidbody> ()) {
			//if (collider.GetComponent<Rigidbody> ().mass <= 1f) {
				collider.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 5, 0) * bigger);
			//}
			//Debug.Log(bigger);
			bigger++;

		}
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
