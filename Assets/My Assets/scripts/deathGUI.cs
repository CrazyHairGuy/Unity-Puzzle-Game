using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathGUI : MonoBehaviour {
	public Button restartButton;

	// Use this for initialization
	void Start () {
		restartButton.onClick.AddListener (Restart);
	}

	void Restart(){
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
