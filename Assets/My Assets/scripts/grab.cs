using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour {

	GameObject grabbedObject;
//	float grabbedObjectSize;
	//Quaternion lookRot;
	public float speed = 5.0f;
	public float rotSpeed = 5.0f;
	public Vector3 offset = new Vector3(0, 1, 0);
	Quaternion lookRot;
	public GameObject xRay;
	Vector3 newPosition;
	public float offsetDistance = 1;
	Vector3 size = new Vector3 (2, 2, 3);
	public GameObject hand;
	public float scale = 0.1f;
	public GameObject trigger;
	//GameObject[] pickUppable;

	/*Quaternion lookRot(Quaternion cameraRot){
	
		return cameraRot.SetLookRotation (Camera.main.transform.position, Vector3.up);

	}*/

	GameObject getMouseHoverObject(float range){
		
		Vector3 position = gameObject.transform.position;
		RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * range;
		if (Physics.Linecast (position, target, out raycastHit))
			return raycastHit.collider.gameObject;
		return null;

	}

	void TryGrabbedObject(GameObject grabObject){

		if (grabObject == null || !CanGrab(grabObject))
			return;

		grabbedObject = grabObject;
		//grabbedObjectSize = grabObject.GetComponent<MeshRenderer> ().bounds.size.magnitude;
		grabbedObject.GetComponent<Rigidbody> ().isKinematic = true;
		grabbedObject.GetComponent<BoxCollider> ().isTrigger = true;
		//grabbedObject.layer = 11;
		//xRay.SetActive (true);
		
	}

	bool CanGrab(GameObject candidate){

		if(candidate.CompareTag("grab")/* && grabbedObject.GetComponent<grabbable>()*/)
			return true;
		return false;

	}

	bool PrepareDropObject(){

		Vector3 position = gameObject.transform.position;
		RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * 5;

		if (grabbedObject == null)
			return false;
		if (grabbedObject.GetComponent<Rigidbody> () != null && trigger.GetComponent<grabbable>().count == 0 && grabbedObject.transform.localScale == new Vector3(0.5f, 0.5f, 0.5f) /*&& Physics.Linecast (position, target, out raycastHit) == grabbedObject*/) {
			grabbedObject.GetComponent<Rigidbody> ().isKinematic = false;
			grabbedObject.GetComponent<BoxCollider> ().isTrigger = false;
			grabbedObject.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity;
			//	xRay.SetActive (false);
			//	grabbedObject.layer = 0;
			return true;
		}
		return false;
	}

	void DropObject(){

		if(PrepareDropObject () == true)
			grabbedObject = null;
	}

	void ThrowObject(){

		if (PrepareDropObject () == true) {
			grabbedObject.GetComponent<Rigidbody> ().AddForce (Camera.main.transform.forward * 150);
			grabbedObject = null;
		}
	}

	void CompressGrabbedObject(){
	
		grabbedObject.transform.localScale = Vector3.Lerp(grabbedObject.transform.localScale, new Vector3(scale, scale, scale), Time.deltaTime * speed);
		newPosition = (hand.transform.position); //+ offset;
		grabbedObject.transform.rotation = Quaternion.Lerp (grabbedObject.transform.rotation, hand.transform.rotation, Time.deltaTime * rotSpeed * 2);
		//grabbedObject.GetComponent<BoxCollider> ().center = Vector3.forward * offsetDistance;
		//grabbedObject.GetComponent<BoxCollider> ().size = size;
		grabbedObject.layer = 11;
		xRay.SetActive (true);
	
	}

	void HoldGrabbedObject(){

		grabbedObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		newPosition = (gameObject.transform.position + Camera.main.transform.forward * 2) + offset;
		grabbedObject.transform.rotation = Quaternion.Lerp (grabbedObject.transform.rotation, lookRot, Time.deltaTime * rotSpeed);
		//grabbedObject.GetComponent<BoxCollider> ().center = Vector3.zero;
		xRay.SetActive (false);
		grabbedObject.layer = 0;

	}

	void SetRotationAndPosition(){

		if (grabbedObject != null) {
			lookRot.Set (this.transform.rotation [0], Camera.main.transform.rotation [1], this.transform.rotation [2], Camera.main.transform.rotation [3]);
			trigger.transform.rotation = lookRot;
			grabbedObject.transform.position = Vector3.Lerp (grabbedObject.transform.position, newPosition, Time.deltaTime * speed);
		}

	}
	
	// Update is called once per frame
	void Update () {

		//pickUppable = GameObject.FindWithTag ("interactable");
		SetRotationAndPosition();
		//Debug.Log (trigger.GetComponent<grabbable> ().count);

		if (Input.GetKeyDown ("e")) {
			if (grabbedObject == null)
				TryGrabbedObject (getMouseHoverObject (5));
			else
				DropObject ();
		}
		if (grabbedObject != null) {

			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				ThrowObject ();
			}

			if (trigger.GetComponent<grabbable> ().count > 0) {
				CompressGrabbedObject ();
			} else {
				HoldGrabbedObject ();
			}
			//Quaternion lookRot = Quaternion.LookRotation (Camera.main.transform.position, Vector3.up);
			//Quaternion newRotation = Quaternion.Lerp (grabbedObject.transform.rotation, lookRot, Time.deltaTime * rotSpeed);
			//lookRot.Set(this.transform.rotation[0], Camera.main.transform.rotation[1], this.transform.rotation[2], Camera.main.transform.rotation[3]);

			//trigger.transform.rotation = Quaternion.Lerp (grabbedObject.transform.rotation, lookRot, Time.deltaTime * rotSpeed);



			//grabbedObject.transform.rotation = newRotation;
		}
	}
}
