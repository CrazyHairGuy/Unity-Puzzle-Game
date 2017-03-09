using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathGUI : MonoBehaviour {
	public Button restartButton;
	public Button mainMenuButton;

	// Use this for initialization
	void Start () {
		restartButton.onClick.AddListener (Restart);
		mainMenuButton.onClick.AddListener (MainMenu);
	}

	void Restart(){
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

	void MainMenu(){
		SceneManager.LoadScene ("menu");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
