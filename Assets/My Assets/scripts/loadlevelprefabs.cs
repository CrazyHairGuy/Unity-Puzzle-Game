using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadlevelprefabs : MonoBehaviour {

	public levelprefabs prefab;
	public GameObject pauseMenu;
	public GameObject HUD;

	// Use this for initialization
	void Start () {

		pauseMenu = Instantiate (prefab.pauseMenu) as GameObject;
		HUD = Instantiate (prefab.HUD) as GameObject;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
