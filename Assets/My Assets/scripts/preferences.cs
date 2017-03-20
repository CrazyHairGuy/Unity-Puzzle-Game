using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class preferences : MonoBehaviour {

	public options option;
	bool isHovering;
	public bool menuIsActive;
	Color defaultColor;
	Vector3 defaultPos;
	Vector3 defaultCamPos;
	Vector3 defaultTitlePos;
	Quaternion defaultTitleRot;
	public Vector3 offset = new Vector3(2, 0, -2);
	public float speed = 5;
	public GameObject optionMenu;
	public GameObject menuPos;
	public GameObject menuTitlePos;
	public GameObject titlePos;
	public GameObject title;
	public GameObject camPosOne;
	public Camera pauseCam;
	GameObject scriptball;
	public GameObject optionText;
	public GameObject load;
	//public Transform DOFFocus;

	void OnMouseEnter(){
		isHovering = true;
	}

	void OnMouseExit(){
		isHovering = false;
	}

	void Start () {
		defaultColor = optionText.GetComponent<MeshRenderer> ().material.color;
		defaultPos = optionText.transform.localPosition;
		defaultCamPos = pauseCam.transform.position;
		defaultTitlePos = title.transform.position;
		defaultTitleRot = title.transform.rotation;
		scriptball = GameObject.FindGameObjectWithTag ("ScriptBall");
		//Debug.Log (gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {

		if (load.GetComponent<loadsceneone> ().menuIsActive == false) {
			if (SceneManager.GetActiveScene().name.Equals("menu") == false) {
				
				if (!CrossPlatformInputManager.GetButton ("Lock")) {
					if (Camera.main.GetComponent<DepthOfField> ().enabled) {
						RaycastHit DOFHit;
						Ray DOFRay = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
						if (Physics.Raycast (DOFRay, out DOFHit)) {
							//DOFFocus.position = DOFHit.point;
							Camera.main.GetComponent<DepthOfField> ().focalTransform.position = DOFHit.point;
						}
					}
				}
					
				if (option.bloom)
					Camera.main.GetComponent<Bloom> ().enabled = true;
				else
					Camera.main.GetComponent<Bloom> ().enabled = false;
				if (option.abberation)
					Camera.main.GetComponent<VignetteAndChromaticAberration> ().enabled = true;
				else
					Camera.main.GetComponent<VignetteAndChromaticAberration> ().enabled = false;
				if (option.DoF)
					Camera.main.GetComponent<DepthOfField> ().enabled = true;
				else
					Camera.main.GetComponent<DepthOfField> ().enabled = false;
				if (option.noise)
					Camera.main.GetComponent<NoiseAndGrain> ().enabled = true;
				else
					Camera.main.GetComponent<NoiseAndGrain> ().enabled = false;
					
			}


		/*if (isHovering) {
			optionText.transform.localPosition = Vector3.Lerp (optionText.transform.localPosition, defaultPos + offset, Time.deltaTime * speed);
		} else {
			if (menuIsActive == true)
				optionText.transform.localPosition = Vector3.Lerp (optionText.transform.localPosition, menuTitlePos.transform.position, Time.deltaTime * speed);
			else
				optionText.transform.localPosition = Vector3.Lerp (optionText.transform.localPosition, defaultPos, Time.deltaTime * speed);
		}*/
		//if (levelOne.GetComponent<scenemenu> ().isPressed == false) {
			if (menuIsActive == false) {
				if (scriptball != null)
					scriptball.GetComponent<loadlevelprefabs>().pauseMenu.GetComponentInChildren<pausemenu>().onOptionsMenu = false;
				pauseCam.GetComponent<DepthOfField> ().focalTransform = title.transform;
				optionMenu.transform.localPosition = Vector3.Lerp (optionMenu.transform.localPosition, new Vector3 (-2.3f, 0.60f, 0), Time.deltaTime * speed);
				//optionMenu.transform.localScale = new Vector3 (4.5f, 0.9f, 0.2f);
				optionMenu.transform.localScale = Vector3.Lerp (optionMenu.transform.localScale, new Vector3 (3.3f, 0, 0), Time.deltaTime * speed * 3);
				title.transform.position = Vector3.Lerp (title.transform.position, defaultTitlePos, Time.deltaTime * speed);
				title.transform.rotation = Quaternion.Lerp (title.transform.rotation, defaultTitleRot, Time.deltaTime * speed);
				//title.transform.position = defaultTitlePos;
				pauseCam.transform.position = Vector3.Lerp (pauseCam.transform.position, defaultCamPos, Time.deltaTime * speed);
				//optionMenu.SetActive (false);
				if (isHovering == true) {
					optionText.transform.localPosition = Vector3.Lerp (optionText.transform.localPosition, defaultPos + offset, Time.deltaTime * speed);
					pauseCam.GetComponent<DepthOfField> ().focalTransform = this.optionText.transform;
					optionText.GetComponent<MeshRenderer> ().material.color = Color.gray;
					//optionText.GetComponent<BoxCollider>().transform.localPosition = Vector3.Lerp (optionText.transform.localPosition, new Vector3(-offset, 0, 0), Time.deltaTime * speed);
					if (CrossPlatformInputManager.GetButtonUp ("Throw")) {
						menuIsActive = true;
						//SceneManager.LoadScene ("rev 2 experimental");
					}
				} else {
					//optionText.GetComponent<BoxCollider>().transform.localPosition = Vector3.Lerp(optionText.transform.localPosition, defaultPos + new Vector3(0, 0, 0), Time.deltaTime * speed);
					optionText.GetComponent<MeshRenderer> ().material.color = defaultColor;
					optionText.transform.localPosition = Vector3.Lerp (optionText.transform.localPosition, defaultPos, Time.deltaTime * speed);
				}
			} else {
				//optionMenu.SetActive (true);
				if (CrossPlatformInputManager.GetButtonDown ("Pause")) {
					menuIsActive = false;
				}
				if (scriptball !=null)
					scriptball.GetComponent<loadlevelprefabs>().pauseMenu.GetComponentInChildren<pausemenu>().onOptionsMenu = true;
				optionMenu.transform.position = Vector3.Lerp (optionMenu.transform.position, menuPos.transform.position, Time.deltaTime * speed);
				title.transform.position = Vector3.Lerp (title.transform.position, titlePos.transform.position, Time.deltaTime * speed);
				title.transform.rotation = Quaternion.Lerp (title.transform.rotation, titlePos.transform.rotation, Time.deltaTime * speed);
				optionMenu.transform.localScale = Vector3.Lerp (optionMenu.transform.localScale, new Vector3 (5, 4, 0.2f), Time.deltaTime * speed);
				pauseCam.transform.position = Vector3.Lerp (pauseCam.transform.position, camPosOne.transform.position, Time.deltaTime * speed);
				pauseCam.GetComponent<DepthOfField> ().focalTransform = optionMenu.gameObject.transform;
				optionText.transform.position = Vector3.Lerp (optionText.transform.position, menuTitlePos.transform.position, Time.deltaTime * speed * 2);
				optionText.GetComponent<MeshRenderer> ().material.color = defaultColor;
			}
		//} else {
			//
		//	pauseCam.transform.position = Vector3.Lerp (pauseCam.transform.position, camPosTwo.transform.position, Time.deltaTime * speed);
		//}
		}
	}
}
