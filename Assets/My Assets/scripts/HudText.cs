using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudText : MonoBehaviour {

	public GameObject player;
	public Text axis;
	public Text size;
	public GameObject grabbedObjectHud;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<grab> ().grabbedObject != null) {
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
		}
	}
}
