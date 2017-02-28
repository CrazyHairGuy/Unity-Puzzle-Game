using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primaryfire : MonoBehaviour {

	public GameObject projectile;
	public GameObject barrel;
	public GameObject[] gameObjects;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("t"))
		{
		    gameObjects = GameObject.FindGameObjectsWithTag ("projectile");
     
     		for(var i = 0 ; i < gameObjects.Length ; i ++)
    		 {
      		   Destroy(gameObjects[i]);
    		 }
 }


		if (Input.GetKey(KeyCode.Mouse0))
		{
			GameObject bullet = Instantiate(projectile, barrel.transform.position, Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
			//yield return new WaitForSeconds(0.3f);
		}
	}
}
