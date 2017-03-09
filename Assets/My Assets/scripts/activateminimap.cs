using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class activateminimap : MonoBehaviour {

	bool isHovering;
	public bool isPressed;
	Color defaultColor;
	Vector3 defaultPos;
	public Vector3 offset = new Vector3(0.5f, 0, -0.25f);
	public float speed = 5;
	public GameObject quitText;
	public GameObject minimapCamera;
	public GameObject spriteCamera;
	public GameObject quitButton;
	//public GameObject loading;
	//int timer;
	//public GameObject loadingPos;
	//float deltatime;
	//float fps;

	// Use this for initialization

	void OnMouseEnter(){
		isHovering = true;
	}

	void OnMouseExit(){
		isHovering = false;
	}

	void Start () {
		defaultColor = quitText.GetComponent<MeshRenderer> ().material.color;
		defaultPos = quitText.transform.localPosition;
		//deltatime += (Time.deltaTime - deltatime) * 0.1f;
		//fps = 1.0f / deltatime;
	}

	// Update is called once per frame
	void Update () {

		if (isHovering == true) {
			Camera.main.GetComponent<DepthOfField> ().focalTransform = this.quitText.transform;
			quitText.GetComponent<MeshRenderer> ().material.color = Color.gray;
			quitText.transform.localPosition = Vector3.Lerp(quitText.transform.localPosition, defaultPos + offset, Time.deltaTime * speed);
			//quitText.GetComponent<BoxCollider>().transform.localPosition = Vector3.Lerp (quitText.transform.localPosition, new Vector3(-offset, 0, 0), Time.deltaTime * speed);
			if (CrossPlatformInputManager.GetButtonUp ("Throw")) {
				if (Display.displays.Length > 1) {
					Display.displays [1].Activate ();
					spriteCamera.SetActive (true);
					minimapCamera.SetActive (true);

					quitButton.transform.position = gameObject.transform.position;
					gameObject.SetActive (false);
				}
				//loading.transform.localScale = Vector3.Lerp (loading.transform.localScale, new Vector3(0.2f, 0.2f, 5), Time.deltaTime * speed);
				//SceneManager.LoadScene ("rev 2 experimental");
			}
		} else {
			quitText.transform.localPosition = Vector3.Lerp (quitText.transform.localPosition, defaultPos, Time.deltaTime * speed);
			//quitText.GetComponent<BoxCollider>().transform.localPosition = Vector3.Lerp(quitText.transform.localPosition, defaultPos + new Vector3(0, 0, 0), Time.deltaTime * speed);
			quitText.GetComponent<MeshRenderer> ().material.color = defaultColor;
			//if (isPressed){
			//	loading.transform.localScale = Vector3.Lerp (loading.transform.localScale, new Vector3(1f, 1f, 25), Time.deltaTime * speed);
			//	loading.transform.position = Vector3.Lerp (loading.transform.position, loadingPos.transform.position, Time.deltaTime * speed);
			//Camera.main.GetComponent<DepthOfField> ().focalTransform = loading.quitText.transform;
			//timer++;
			//if (timer > 30)
			//	SceneManager.LoadScene ("rev 2 experimental");
			//}
		}
	}
}
