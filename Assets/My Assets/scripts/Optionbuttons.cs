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

		if (isHovering == true) {
			Camera.main.GetComponent<DepthOfField> ().focalTransform = this.text.transform;
			//text.GetComponent<MeshRenderer> ().material.color = Color.gray;
			text.transform.localPosition = Vector3.Lerp(text.transform.localPosition, defaultPos + offset, Time.deltaTime * speed);
			if (CrossPlatformInputManager.GetButtonUp ("Throw")) {

				if (gameObject.name.Equals ("abberation"))
					option.abberation = !option.abberation;

				if (gameObject.name.Equals ("bloom"))
					option.bloom = !option.bloom;

				if (gameObject.name.Equals ("noise"))
					option.noise = !option.noise;

				if (gameObject.name.Equals ("DoF"))
					option.DoF = !option.DoF;
					

			}
		} else {
			text.transform.localPosition = Vector3.Lerp (text.transform.localPosition, defaultPos, Time.deltaTime * speed);
			//text.GetComponent<MeshRenderer> ().material.color = defaultColor;
		}
	}
}
