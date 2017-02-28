using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour {
	public GameObject menu;
	public GameObject pausecam;
	public GameObject player;
	public GameObject hud;
	private bool isShowing = false;
	public Button restartButton;
	public Button quitButton;
	// Use this for initialization
	void Start () {
		
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		quitButton.onClick.AddListener (Quit);
		restartButton.onClick.AddListener (Restart);

	}

	void Quit(){
		Application.Quit();
	}

	void Restart(){
		SceneManager.LoadScene ("rev 2 experimental.unity");
	}

	// Update is called once per frame
	void Update () {


		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isShowing = !isShowing;
			menu.SetActive (isShowing);
			pausecam.SetActive (isShowing);
			player.SetActive (!isShowing);
			hud.SetActive (!isShowing);
		}

		if (isShowing == true) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Time.timeScale = 0.0f;
		}
		else {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Time.timeScale = 1.0f;
		}
	}
}
