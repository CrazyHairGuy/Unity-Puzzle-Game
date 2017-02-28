using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hud : MonoBehaviour {

	public GameObject HUDCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Cursor.lockState == CursorLockMode.Locked)
			HUDCanvas.SetActive(true);
		else
			HUDCanvas.SetActive(false);

	}
}
