using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbable : MonoBehaviour {

	// Use this for initialization

	public int count = 0;
	//public GameObject player;
	//public int player = 0;

	void OnTriggerEnter(Collider collider){

	

		if (collider.CompareTag ("trigger_button") == false && collider.CompareTag ("Player") == false && collider.CompareTag ("grab") == false) {
			count ++;
			//Debug.Log (collider.name);
		} //else {
		//	if (player.GetComponent<grab> ().grabbedObject != null) {
		//		if (collider.name != player.GetComponent<grab> ().grabbedObject.name)
			//		count ++;
			//		}
		//}
		
		//if(collider.CompareTag("trigger_button") == false)
		//	player += 1;

	}

	void OnTriggerExit(Collider collider){
		
		if (collider.CompareTag ("trigger_button") == false && collider.CompareTag ("Player") == false && collider.CompareTag ("grab") == false) {
			count -= 1;
			//Debug.Log (collider.name);
		} //else {
			//if (player.GetComponent<grab> ().grabbedObject != null) {
			//	if (collider.name != player.GetComponent<grab> ().grabbedObject.name)
			//		count --;
			//}
		//}

		//if(collider.CompareTag("trigger_button") == false)
		//	player -= 1;
		
	}

	/*string ToString(){
		return count;
	}*/

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
