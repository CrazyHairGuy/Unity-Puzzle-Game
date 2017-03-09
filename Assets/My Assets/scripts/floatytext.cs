using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatytext : MonoBehaviour {

	Vector3 upPos;
	Vector3 originalPos;
	int timer;
	public float verticalOffset = 0.5f;

	// Use this for initialization
	void Start () {

		upPos = gameObject.transform.position + new Vector3 (0, verticalOffset, 0);
		originalPos = upPos - new Vector3 (0, verticalOffset, 0);
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if (timer > 60)
			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, upPos, Time.deltaTime);
		if (timer > 120) {
			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, originalPos, Time.deltaTime);
		}
		if (timer > 150) 
			timer = 0;
	}
}
