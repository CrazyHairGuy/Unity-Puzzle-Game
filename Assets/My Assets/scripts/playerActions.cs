using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;



public class playerActions : MonoBehaviour {

	public GameObject scriptball;
	public GameObject crouchTriggerObject;
	float walkSpeed;
	// Use this for initialization
	void Start () {

		walkSpeed = gameObject.GetComponent<FirstPersonController> ().m_WalkSpeed;
		//crouchSpeed = walkSpeed * (3 / 5);

	}

	// Update is called once per frame
	void Update () {

		//Debug.Log (walkSpeed);

		if(scriptball.GetComponent<pausemenu>().isShowing == false) {
			
			if (CrossPlatformInputManager.GetButton ("Crouch")) {
				gameObject.GetComponent<CharacterController> ().height = 0.4f;
				gameObject.GetComponent<CharacterController> ().radius = 0.4f;
				gameObject.GetComponent<FirstPersonController> ().m_WalkSpeed = gameObject.GetComponent<FirstPersonController> ().CrouchSpeed;
				//player.GetComponent<CharacterController> ().height = Mathf.Lerp (player.GetComponent<CharacterController> ().height, 0.9f, Time.deltaTime * 10);
				//player.GetComponent<CharacterController>().transform.localScale = Vector3.Lerp (player.transform.localScale, new Vector3 (1, 0.5f, 1), Time.deltaTime * 10);
				//Camera.main.transform.position = new Vector3 (0, 0, 0);
			} else {
				if (crouchTriggerObject.GetComponent<crouchTrigger> ().count <= 0){
					gameObject.GetComponent<CharacterController> ().height = 1.8f;
					gameObject.GetComponent<CharacterController> ().radius = 0.5f;
					gameObject.GetComponent<FirstPersonController> ().m_WalkSpeed = walkSpeed;
					//player.GetComponent<CharacterController> ().height = Mathf.Lerp (player.GetComponent<CharacterController> ().height, 1.8f , Time.deltaTime * 10);
					//player.transform.localScale = Vector3.Lerp (player.transform.localScale, new Vector3 (1, 1, 1), Time.deltaTime * 10);
					//Camera.main.transform.position = new Vector3 (0, 0, 0);
				}
			}
		}
	}
}
