using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {

	public static death Instance;

	public GameObject deathGUI;
	public GameObject deathCam;
	public GameObject deathText;
	public GameObject restartButton;
	public GameObject HUD;
	int timer = 0;
	bool dead;

	public void Die(GameObject player){

		dead = true;
		GameObject head = Instantiate(deathCam, Camera.main.transform.position, Camera.main.transform.rotation) as GameObject;
		head.GetComponent<Rigidbody> ().velocity = player.GetComponent<CharacterController> ().velocity;
		player.GetComponent<grab> ().DropObject ();
		player.SetActive(false);
		gameObject.GetComponent<pausemenu> ().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		HUD.SetActive (false);
		deathGUI.SetActive (true);
	
	}

	// Use this for initialization
	void Start () {

		Instance = this;

	}
	
	// Update is called once per frame
	void Update () {

		if (dead)
			timer++;
		//Debug.Log (timer);

		if (timer > 30) {
			deathText.SetActive (true);
			restartButton.SetActive (true);
		}
	}
}
