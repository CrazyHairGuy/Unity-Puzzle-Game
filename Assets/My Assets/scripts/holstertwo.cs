using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holstertwo : MonoBehaviour {

    // public Vector3 destination;
	//public GameObject holster;
	//public GameObject hip;
	public GameObject gun;
     //public float speed = 0.1f;
 
     void Start () {
		
		//transform.position = Vector3.MoveTowards (holster.transform.position, hip.transform.position, speed * Time.deltaTime);

		//destination = transform.position;

     }
     
     void Update () {

		if (Input.GetKeyDown(KeyCode.Q))
			{
			//transform.position = Vector3.MoveTowards (hip.transform.position, holster.transform.position, speed * Time.deltaTime);

			gun.SetActive (true);
			gameObject.SetActive (false);
			} 

     }
}
