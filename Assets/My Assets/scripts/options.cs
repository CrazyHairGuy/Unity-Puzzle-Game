using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Options", menuName = "Options", order = 1)]
public class options : ScriptableObject {

	[Header("Video Effects")]
	//public bool antialiasing;
	public bool bloom = false;
	public bool abberation = false;
	public bool DoF = false;
	public bool noise = false;
	public bool monitor = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
