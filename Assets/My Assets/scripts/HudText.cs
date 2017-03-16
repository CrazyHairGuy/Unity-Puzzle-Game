﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudText : MonoBehaviour {

	GameObject player;
	public Text axis;
	public Text size;
	public GameObject grabbedObjectHud;
	public Image throe;
	public Image resize;
	public Image hurl;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<grab> ().grabbedObject != null) {

			if (player.GetComponent<grab> ().grabbedObject.GetComponent<grabvars> ().canResize == false)
				resize.color = Color.red;
			else
				resize.color = Color.green;
			if (player.GetComponent<grab> ().grabbedObject.GetComponent<grabvars> ().canThrow == false)
				throe.color = Color.red;
			else
				throe.color = Color.green;
			if (player.GetComponent<grab> ().grabbedObject.GetComponent<grabvars> ().canHurl == false)
				hurl.color = Color.red;
			else
				hurl.color = Color.green;

			grabbedObjectHud.SetActive (true);
			if (player.GetComponent<grab> ().grabbedObject.GetComponent<grabvars> ().canResize == false) {
				axis.text = "No";
				size.text = "Resizing";
			} else {
				if (player.GetComponent<grab> ().resize == 0) {
					axis.text = "X";
					size.text = string.Format ("{0:N2}", player.GetComponent<grab> ().grabbedObject.transform.localScale.x * 2);
				}

				if (player.GetComponent<grab> ().resize == 1) {
					axis.text = "Y";
					size.text = string.Format ("{0:N2}", player.GetComponent<grab> ().grabbedObject.transform.localScale.y * 2);
				}
		
				if (player.GetComponent<grab> ().resize == 2) {
					axis.text = "Z";
					size.text = string.Format ("{0:N2}", player.GetComponent<grab> ().grabbedObject.transform.localScale.z * 2);
				}
			}
		} else {
			grabbedObjectHud.SetActive (false);
			resize.color = Color.white;
			throe.color = Color.white;
			hurl.color = Color.white;
		}
	//	if (player.GetComponent<grab> ().getMouseHoverObject (5) != null) {
	//		resize.color = Color.yellow;
	//		throe.color = Color.yellow;
	//		hurl.color = Color.yellow;
	//	} else {
	//		resize.color = Color.white;
	//		throe.color = Color.white;
	//		hurl.color = Color.white;
	//	}
	}
}
