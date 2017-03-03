using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class grab : MonoBehaviour {

	public GameObject grabbedObject;
	float grabbedObjectSize;
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
	int resize = 0;
	int activate = 0;
	Vector3 scaleHold;

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
		grabbedObjectSize = grabObject.GetComponent<MeshRenderer> ().bounds.size.magnitude;
		grabbedObject.GetComponent<Rigidbody> ().isKinematic = true;
		grabbedObject.GetComponent<BoxCollider> ().isTrigger = true;
		
	}

	bool CanGrab(GameObject candidate){

		if(candidate.CompareTag("grab"))
			return true;
		return false;

	}

	bool PrepareDropObject(){
		
		if (grabbedObject == null)
			return false;
		if (grabbedObject.GetComponent<Rigidbody> () != null && trigger.GetComponent<grabbable>().count == 0 /*&& grabbedObject.transform.localScale == new Vector3(0.5f, 0.5f, 0.5f)*/) {
			grabbedObject.GetComponent<Rigidbody> ().isKinematic = false;
			grabbedObject.GetComponent<BoxCollider> ().isTrigger = false;
			grabbedObject.GetComponent<Rigidbody> ().velocity = this.GetComponent<CharacterController> ().velocity;
			return true;
		}
		return false;
	}

	void DropObject(){

		if(PrepareDropObject () == true)
			grabbedObject = null;
	}

	void ThrowObject(int force){

		if (PrepareDropObject () == true) {
			grabbedObject.GetComponent<Rigidbody> ().AddForce (Camera.main.transform.forward * force);
			grabbedObject = null;
		}
	}

	void CompressGrabbedObject(){
		
		if (activate == 0)
			scaleHold = grabbedObject.transform.localScale;
			grabbedObject.transform.localScale = Vector3.Lerp(grabbedObject.transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), Time.deltaTime * speed);
		
		newPosition = (hand.transform.position);
		grabbedObject.transform.rotation = Quaternion.Lerp (grabbedObject.transform.rotation, hand.transform.rotation, Time.deltaTime * rotSpeed * 2);
		grabbedObject.layer = 11;
		xRay.SetActive (true);
		activate = 1;
	
	}

	void HoldGrabbedObject(){

		if (grabbedObject != null) {
			
			if (activate == 1)
				grabbedObject.transform.localScale = scaleHold;
				//grabbedObject.transform.localScale = new Vector3 (grabbedObject.transform.localScale.x + 5, grabbedObject.transform.localScale.y + 5, grabbedObject.transform.localScale.y + 5);

			newPosition = (gameObject.transform.position + Camera.main.transform.forward * 2 /* + Camera.main.transform.forward * grabbedObject.transform.localScale.z*/) + offset;
			grabbedObject.transform.rotation = Quaternion.Lerp (grabbedObject.transform.rotation, lookRot, Time.deltaTime * rotSpeed);
			xRay.SetActive (false);
			grabbedObject.layer = 0;
			activate = 0;
		}

	}

	void SetRotationAndPosition(){

		if (grabbedObject != null) {
			lookRot.Set (this.transform.rotation [0], Camera.main.transform.rotation [1], this.transform.rotation [2], Camera.main.transform.rotation [3]);
			trigger.transform.rotation = lookRot;
			grabbedObject.transform.position = Vector3.Lerp (grabbedObject.transform.position, newPosition, Time.deltaTime * speed);
		}

	}

	void ResizeObject(int axis){

		float MouseWheel = CrossPlatformInputManager.GetAxis ("Mouse ScrollWheel");
		float MouseWheelScale = MouseWheel + 1.0f;
		float MaxX, MaxY, MaxZ;


		Debug.Log (MouseWheel);

		if (MouseWheel != 0 && axis == 0 && (grabbedObject.transform.localScale.x >= 0 || MouseWheel >= 0)) {

			if (grabbedObject.transform.localScale.x * MouseWheelScale >= 1.5f) {
				MaxX = 1.5f;
			} else {
				MaxX = grabbedObject.transform.localScale.x * MouseWheelScale;
			}
			if (grabbedObject.transform.localScale.x * MouseWheelScale <= 0.1f)
				MaxX = 0.1f;

			grabbedObject.transform.localScale = Vector3.Lerp (grabbedObject.transform.localScale, new Vector3 (MaxX, grabbedObject.transform.localScale.y, grabbedObject.transform.localScale.z), Time.deltaTime * speed);
		}
		
		if (MouseWheel != 0 && axis == 1 && (grabbedObject.transform.localScale.x >= 0 || MouseWheel >= 0)) {

			if (grabbedObject.transform.localScale.y * MouseWheelScale >= 1.5f) {
				MaxY = 1.5f;
			} else {
				MaxY = grabbedObject.transform.localScale.y * MouseWheelScale;
			}
			if (grabbedObject.transform.localScale.y * MouseWheelScale <= 0.1f)
				MaxY = 0.1f;

			grabbedObject.transform.localScale = Vector3.Lerp (grabbedObject.transform.localScale, new Vector3 (grabbedObject.transform.localScale.x, MaxY, grabbedObject.transform.localScale.z), Time.deltaTime * speed);
		}
		
		if (MouseWheel != 0 && axis == 2 && (grabbedObject.transform.localScale.x >= 0 || MouseWheel >= 0)) {

			if (grabbedObject.transform.localScale.z * MouseWheelScale >= 1.5f) {
				MaxZ = 1.5f;
			} else {
				MaxZ = grabbedObject.transform.localScale.z * MouseWheelScale;
			}
			if (grabbedObject.transform.localScale.z * MouseWheelScale <= 0.1f)
				MaxZ = 0.1f;
				
			grabbedObject.transform.localScale = Vector3.Lerp (grabbedObject.transform.localScale, new Vector3 (grabbedObject.transform.localScale.x, grabbedObject.transform.localScale.y, MaxZ), Time.deltaTime * speed);
		}
				

	}

	void ResetScale(){
		scaleHold = new Vector3 (0.5f, 0.5f, 0.5f);
		grabbedObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
		SetRotationAndPosition();
		//Debug.Log (trigger.GetComponent<grabbable> ().count);

		if (CrossPlatformInputManager.GetButtonDown ("Use")) {
			if (grabbedObject == null)
				TryGrabbedObject (getMouseHoverObject (5));
			else
				DropObject ();
		}
		if (grabbedObject != null) {

			if (grabbedObject.GetComponent<grabvars> ()) {
				
				if (grabbedObject.GetComponent<grabvars> ().canResize) {
					
					ResizeObject (resize);

					if (CrossPlatformInputManager.GetButtonDown ("Resize X Axis"))
						resize = 0;

					if (CrossPlatformInputManager.GetButtonDown ("Resize Y Axis"))
						resize = 1;

					if (CrossPlatformInputManager.GetButtonDown ("Resize Z Axis"))
						resize = 2;

					if (CrossPlatformInputManager.GetButtonDown ("Reset Scale"))
						ResetScale ();
				}

				if (CrossPlatformInputManager.GetButtonDown ("Throw") && grabbedObject.GetComponent<grabvars> ().canThrow) {
					ThrowObject (150);
				}

				if (CrossPlatformInputManager.GetButtonDown ("Hurl") && grabbedObject.GetComponent<grabvars> ().canHurl) {
					ThrowObject (1000);
				}
			} else {

				if (CrossPlatformInputManager.GetButtonDown ("Throw")) {
					ThrowObject (150);
				}

				if (CrossPlatformInputManager.GetButtonDown ("Hurl")) {
					ThrowObject (1000);
				}

				ResizeObject (resize);

				if (CrossPlatformInputManager.GetButtonDown ("Resize X Axis"))
					resize = 0;

				if (CrossPlatformInputManager.GetButtonDown ("Resize Y Axis"))
					resize = 1;

				if (CrossPlatformInputManager.GetButtonDown ("Resize Z Axis"))
					resize = 2;

				if (CrossPlatformInputManager.GetButtonDown ("Reset Scale"))
					ResetScale ();
			}
				
			if (trigger.GetComponent<grabbable> ().count > 0) {
				CompressGrabbedObject ();
			} else {
				HoldGrabbedObject ();
				trigger.transform.localScale = grabbedObject.transform.localScale;// + new Vector3(0.5f,0.5f,0.5f);
			}
		}
	}
}
