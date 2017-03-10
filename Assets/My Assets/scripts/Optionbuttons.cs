using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class Optionbuttons: MonoBehaviour {

	bool isHovering;
	public bool isPressed;
	Color defaultColor;
	Vector3 defaultPos;
	public Vector3 offset = new Vector3(-0.25f, 0, 0.5f);
	public float speed = 5;
	public GameObject text;
	public options option;
	public Camera pauseCam;
	public GameObject ex;
	public GameObject oh;
	public Vector3 defaultIndicatorPos;
	public GameObject indicatorPos;

	// Use this for initialization

	void OnMouseEnter(){
		isHovering = true;
	}

	void OnMouseExit(){
		isHovering = false;
	}

	void Start () {
		//defaultColor = text.GetComponent<MeshRenderer> ().material.color;
		defaultPos = text.transform.localPosition;
	}

	// Update is called once per frame
	void Update () {

		defaultIndicatorPos = indicatorPos.transform.position;

		if (gameObject.name.Equals ("abberation")) {
			if (option.abberation) {
				ex.transform.position = Vector3.Lerp (ex.transform.position, defaultIndicatorPos - offset, Time.deltaTime * speed);
				oh.transform.position = Vector3.Lerp (oh.transform.position, defaultIndicatorPos, Time.deltaTime * speed);
			} else {
				ex.transform.position = Vector3.Lerp (ex.transform.position, defaultIndicatorPos, Time.deltaTime * speed);
				oh.transform.position = Vector3.Lerp (oh.transform.position, defaultIndicatorPos - offset, Time.deltaTime * speed);
			}
		}
		if (gameObject.name.Equals ("bloom")) {
			if (option.bloom) {
				ex.transform.position = Vector3.Lerp (ex.transform.position, defaultIndicatorPos - offset, Time.deltaTime * speed);
				oh.transform.position = Vector3.Lerp (oh.transform.position, defaultIndicatorPos, Time.deltaTime * speed);
			} else {
				ex.transform.position = Vector3.Lerp (ex.transform.position, defaultIndicatorPos, Time.deltaTime * speed);
				oh.transform.position = Vector3.Lerp (oh.transform.position, defaultIndicatorPos - offset, Time.deltaTime * speed);
			}
		}
		if (gameObject.name.Equals ("noise")) {
			if (option.noise) {
				ex.transform.position = Vector3.Lerp (ex.transform.position, defaultIndicatorPos - offset, Time.deltaTime * speed);
				oh.transform.position = Vector3.Lerp (oh.transform.position, defaultIndicatorPos, Time.deltaTime * speed);
			} else {
				ex.transform.position = Vector3.Lerp (ex.transform.position, defaultIndicatorPos, Time.deltaTime * speed);
				oh.transform.position = Vector3.Lerp (oh.transform.position, defaultIndicatorPos - offset, Time.deltaTime * speed);
			}
		}
		if (gameObject.name.Equals ("DoF")) {
			if (option.DoF) {
				ex.transform.position = Vector3.Lerp (ex.transform.position, defaultIndicatorPos - offset, Time.deltaTime * speed);
				oh.transform.position = Vector3.Lerp (oh.transform.position, defaultIndicatorPos, Time.deltaTime * speed);
			} else {
				ex.transform.position = Vector3.Lerp (ex.transform.position, defaultIndicatorPos, Time.deltaTime * speed);
				oh.transform.position = Vector3.Lerp (oh.transform.position, defaultIndicatorPos - offset, Time.deltaTime * speed);
			}
		}

		if (isHovering == true) {
			pauseCam.GetComponent<DepthOfField> ().focalTransform = this.text.transform;
			//text.GetComponent<MeshRenderer> ().material.color = Color.gray;
			text.transform.localPosition = Vector3.Lerp(text.transform.localPosition, defaultPos + offset, Time.deltaTime * speed);
			if (CrossPlatformInputManager.GetButtonUp ("Throw")) {

				if (gameObject.name.Equals ("abberation")) {
					option.abberation = !option.abberation;
					//oh.SetActive (option.abberation);
					//ex.SetActive (!option.abberation);
				}
				if (gameObject.name.Equals ("bloom")) {
					option.bloom = !option.bloom;
					//oh.SetActive (option.bloom);
					//ex.SetActive (!option.bloom);
				}
				if (gameObject.name.Equals ("noise")) {
					option.noise = !option.noise;
					//oh.SetActive (option.noise);
					//ex.SetActive (!option.noise);
				}
				if (gameObject.name.Equals ("DoF")) {
					option.DoF = !option.DoF;
					//oh.SetActive (option.DoF);
					//ex.SetActive (!option.DoF);
				}

			}
		} else {
			text.transform.localPosition = Vector3.Lerp (text.transform.localPosition, defaultPos, Time.deltaTime * speed);
			//text.GetComponent<MeshRenderer> ().material.color = defaultColor;
		}
	}
}
