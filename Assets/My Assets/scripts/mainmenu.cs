using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

	bool isHovering;

	// Use this for initialization

	void OnMouseEnter(){
		isHovering = true;
	}

	void OnMouseExit(){
		isHovering = false;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (CrossPlatformInputManager.GetButtonUp ("Throw")) {
			SceneManager.LoadScene ("rev 2 experimental");
		}
		
	}
}
