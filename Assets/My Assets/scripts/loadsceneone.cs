using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class loadsceneone : MonoBehaviour {

	bool isHovering;
	public bool menuIsActive;
	Color defaultColor;
	Vector3 defaultPos;
	Vector3 defaultCamPos;
	Vector3 defaultTitlePos;
	Quaternion defaultTitleRot;
	public Vector3 offset = new Vector3(2, 0, -2);
	public float speed = 5;
	public GameObject sceneMenu;
	public GameObject menuPos;
	public GameObject menuTitlePos;
	public GameObject titlePos;
	public GameObject title;
	public GameObject camPosOne;
	public GameObject camPosTwo;
	public GameObject levelOne;
	public GameObject levelTwo;
	public Camera pauseCam;
	int timer;
	GameObject scriptball;
	public GameObject loadText;
	public GameObject optionMenu;


	// Use this for initialization

	void OnMouseEnter(){
		isHovering = true;
	}

	void OnMouseExit(){
		isHovering = false;
	}

	void Start () {
		defaultColor = loadText.GetComponent<MeshRenderer> ().material.color;
		defaultPos = loadText.transform.localPosition;
		defaultCamPos = pauseCam.transform.position;
		defaultTitlePos = title.transform.position;
		defaultTitleRot = title.transform.rotation;
		scriptball = GameObject.FindGameObjectWithTag ("ScriptBall");
	}
	
	// Update is called once per frame
	void Update () {

		if (optionMenu.GetComponent<preferences> ().menuIsActive == false) {
		if (levelOne.GetComponent<scenemenu>().isPressed){
			levelOne.GetComponent<scenemenu>().loading.transform.localScale = Vector3.Lerp (levelOne.GetComponent<scenemenu>().loading.transform.localScale, new Vector3(1f, 1f, 25), Time.deltaTime * speed);
			levelOne.GetComponent<scenemenu>().loading.transform.position = Vector3.Lerp (levelOne.GetComponent<scenemenu>().loading.transform.position, levelOne.GetComponent<scenemenu>().loadingPos.transform.position, Time.deltaTime * speed);
			pauseCam.GetComponent<DepthOfField> ().focalTransform = levelOne.GetComponent<scenemenu>().loading.gameObject.transform;
			timer++;
			if (timer > 30)
				SceneManager.LoadScene ("rev 2 experimental");
		}

		if (levelTwo.GetComponent<scenemenu>().isPressed){
			levelTwo.GetComponent<scenemenu>().loading.transform.localScale = Vector3.Lerp (levelTwo.GetComponent<scenemenu>().loading.transform.localScale, new Vector3(1f, 1f, 25), Time.deltaTime * speed);
			levelTwo.GetComponent<scenemenu>().loading.transform.position = Vector3.Lerp (levelTwo.GetComponent<scenemenu>().loading.transform.position, levelTwo.GetComponent<scenemenu>().loadingPos.transform.position, Time.deltaTime * speed);
			pauseCam.GetComponent<DepthOfField> ().focalTransform = levelTwo.GetComponent<scenemenu>().loading.gameObject.transform;
			timer++;
			if (timer > 30)
				SceneManager.LoadScene ("test");
		}

		/*if (isHovering) {
			loadText.transform.localPosition = Vector3.Lerp (loadText.transform.localPosition, defaultPos + offset, Time.deltaTime * speed);
		} else {
			if (menuIsActive == true)
				loadText.transform.localPosition = Vector3.Lerp (loadText.transform.localPosition, menuTitlePos.transform.position, Time.deltaTime * speed);
			else
				loadText.transform.localPosition = Vector3.Lerp (loadText.transform.localPosition, defaultPos, Time.deltaTime * speed);
		}*/
			if (levelOne.GetComponent<scenemenu> ().isPressed == false) {
				if (menuIsActive == false) {
					if (scriptball != null)
						scriptball.GetComponent<loadlevelprefabs>().pauseMenu.GetComponentInChildren<pausemenu>().onLoadMenu = false;
					pauseCam.GetComponent<DepthOfField> ().focalTransform = title.transform;
					sceneMenu.transform.localPosition = Vector3.Lerp (sceneMenu.transform.localPosition, new Vector3 (-2.3f, 0.60f, 0), Time.deltaTime * speed);
					//sceneMenu.transform.localScale = new Vector3 (4.5f, 0.9f, 0.2f);
					sceneMenu.transform.localScale = Vector3.Lerp (sceneMenu.transform.localScale, new Vector3 (5, 0, 0), Time.deltaTime * speed * 3);
					title.transform.position = Vector3.Lerp (title.transform.position, defaultTitlePos, Time.deltaTime * speed);
					title.transform.rotation = Quaternion.Lerp (title.transform.rotation, defaultTitleRot, Time.deltaTime * speed);
					//title.transform.position = defaultTitlePos;
					pauseCam.transform.position = Vector3.Lerp (pauseCam.transform.position, defaultCamPos, Time.deltaTime * speed);
					//sceneMenu.SetActive (false);
					if (isHovering == true) {
						loadText.transform.localPosition = Vector3.Lerp (loadText.transform.localPosition, defaultPos + offset, Time.deltaTime * speed);
						pauseCam.GetComponent<DepthOfField> ().focalTransform = this.loadText.transform;
						loadText.GetComponent<MeshRenderer> ().material.color = Color.gray;
						//loadText.GetComponent<BoxCollider>().transform.localPosition = Vector3.Lerp (loadText.transform.localPosition, new Vector3(-offset, 0, 0), Time.deltaTime * speed);
						if (CrossPlatformInputManager.GetButtonUp ("Throw")) {
							menuIsActive = true;
							//Debug.Log (menuIsActive);
							//SceneManager.LoadScene ("rev 2 experimental");
						}
					} else {
						//loadText.GetComponent<BoxCollider>().transform.localPosition = Vector3.Lerp(loadText.transform.localPosition, defaultPos + new Vector3(0, 0, 0), Time.deltaTime * speed);
						loadText.GetComponent<MeshRenderer> ().material.color = defaultColor;
						loadText.transform.localPosition = Vector3.Lerp (loadText.transform.localPosition, defaultPos, Time.deltaTime * speed);
					}
				} else {
					//sceneMenu.SetActive (true);
					if (CrossPlatformInputManager.GetButtonDown ("Pause")) {
						menuIsActive = false;
					}
					if (scriptball != null)
						scriptball.GetComponent<loadlevelprefabs>().pauseMenu.GetComponentInChildren<pausemenu>().onLoadMenu = true;
					sceneMenu.transform.position = Vector3.Lerp (sceneMenu.transform.position, menuPos.transform.position, Time.deltaTime * speed);
					title.transform.position = Vector3.Lerp (title.transform.position, titlePos.transform.position, Time.deltaTime * speed);
					title.transform.rotation = Quaternion.Lerp (title.transform.rotation, titlePos.transform.rotation, Time.deltaTime * speed);
					sceneMenu.transform.localScale = Vector3.Lerp (sceneMenu.transform.localScale, new Vector3 (5, 4, 0.2f), Time.deltaTime * speed);
					pauseCam.transform.position = Vector3.Lerp (pauseCam.transform.position, camPosOne.transform.position, Time.deltaTime * speed);
					pauseCam.GetComponent<DepthOfField> ().focalTransform = sceneMenu.gameObject.transform;
					loadText.transform.position = Vector3.Lerp (loadText.transform.position, menuTitlePos.transform.position, Time.deltaTime * speed * 2);
					loadText.GetComponent<MeshRenderer> ().material.color = defaultColor;
				}
			} else {

				pauseCam.transform.position = Vector3.Lerp (pauseCam.transform.position, camPosTwo.transform.position, Time.deltaTime * speed);
			}
		}
	}
}
