using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapcam : MonoBehaviour {

	public GameObject minimapCamera;
	public Vector3 snapPoint;
	public bool playerInRoom;
	public float speed = 5.0f;
	public float roomHeight = 10;

	// Use this for initialization
	void OnTriggerEnter(Collider collider){
		if(collider.CompareTag("Player"))
			playerInRoom = true;
	}

	void OnTriggerExit(Collider collider){
		if(collider.CompareTag("Player"))
			playerInRoom = false;
	}

	void Start () {
		snapPoint = gameObject.transform.position + (Vector3.up * roomHeight);
	}
	
	// Update is called once per frame
	void Update () {
		if(playerInRoom)
			minimapCamera.transform.position = Vector3.Lerp (minimapCamera.transform.position, snapPoint, Time.deltaTime * speed);
		
		//if (minimapCamera.transform.position == snapPoint)
			//	playerInRoom = false;
	}
}
