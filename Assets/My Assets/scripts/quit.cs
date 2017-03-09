using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class quit : MonoBehaviour {

	bool isHovering;
	public bool isPressed;
	Color defaultColor;
	Vector3 defaultPos;
	public Vector3 offset = new Vector3(0.5f, 0, -0.25f);
	public float speed = 5;
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
		defaultColor = gameObject.GetComponent<MeshRenderer> ().material.color;
		defaultPos = gameObject.transform.localPosition;
		//deltatime += (Time.deltaTime - deltatime) * 0.1f;
		//fps = 1.0f / deltatime;
	}

	// Update is called once per frame
	void Update () {

		if (isHovering == true) {
			Camera.main.GetComponent<DepthOfField> ().focalTransform = this.gameObject.transform;
			gameObject.GetComponent<MeshRenderer> ().material.color = Color.gray;
			gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, defaultPos + offset, Time.deltaTime * speed);
			//gameObject.GetComponent<BoxCollider>().transform.localPosition = Vector3.Lerp (gameObject.transform.localPosition, new Vector3(-offset, 0, 0), Time.deltaTime * speed);
			if (CrossPlatformInputManager.GetButtonUp ("Throw")) {
				Application.Quit();
				//loading.transform.localScale = Vector3.Lerp (loading.transform.localScale, new Vector3(0.2f, 0.2f, 5), Time.deltaTime * speed);
				//SceneManager.LoadScene ("rev 2 experimental");
			}
		} else {
			gameObject.transform.localPosition = Vector3.Lerp (gameObject.transform.localPosition, defaultPos, Time.deltaTime * speed);
			//gameObject.GetComponent<BoxCollider>().transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, defaultPos + new Vector3(0, 0, 0), Time.deltaTime * speed);
			gameObject.GetComponent<MeshRenderer> ().material.color = defaultColor;
			//if (isPressed){
			//	loading.transform.localScale = Vector3.Lerp (loading.transform.localScale, new Vector3(1f, 1f, 25), Time.deltaTime * speed);
			//	loading.transform.position = Vector3.Lerp (loading.transform.position, loadingPos.transform.position, Time.deltaTime * speed);
			//Camera.main.GetComponent<DepthOfField> ().focalTransform = loading.gameObject.transform;
			//timer++;
			//if (timer > 30)
			//	SceneManager.LoadScene ("rev 2 experimental");
			//}
		}
	}
}
