using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplediplays : MonoBehaviour {

	// Use this for initialization
	public GameObject minimapCamera;

	void Start () {
		if (Display.displays.Length > 1) {
			Display.displays [1].Activate ();
			minimapCamera.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
