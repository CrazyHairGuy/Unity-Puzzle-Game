using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.CrossPlatformInput;

public class pausemenu : MonoBehaviour {
	public GameObject menu; //Pause Menu Canvas
	//public GameObject pausecam; //Pause Menu Background (obsolete)
	public GameObject playerCam; //Main Camera
	public GameObject xRay; //Viewmodel Camera
	public GameObject player; //FPS Controller
	public GameObject hud; //Main Hud Canvas
	private bool isShowing = false;
	public Button restartButton;
	public Button quitButton;
	public Button monitorButton;
	bool toggle = false;
	public GameObject minimapCamera;
	//float blurSize; //Default blur size for pause menu
	//public float speed = 5.0f; //Speed for blur in pause menu

	void Start () {
		
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		quitButton.onClick.AddListener (Quit);
		restartButton.onClick.AddListener (Restart);
		monitorButton.onClick.AddListener (ToggleMonitor);
		//blurSize = playerCam.GetComponent<BlurOptimized> ().blurSize;

	}

	void Quit(){
		Application.Quit();
	}

	void Restart(){
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

	void ToggleMonitor(){

		toggle = !toggle;

		if (toggle) {
			if (Display.displays.Length > 1) {
				Display.displays [1].Activate ();
				minimapCamera.SetActive (true);
			}
	//	} else {
	//		Display.displays [1].Activate ();
	//		minimapCamera.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (CrossPlatformInputManager.GetButtonDown("Pause")) {
			isShowing = !isShowing;
			menu.SetActive (isShowing);
			//pausecam.SetActive (isShowing);
			//player.GetComponent<CharacterController>().enabled = !isShowing;
			player.GetComponent<FirstPersonController>().enabled = !isShowing;
			playerCam.GetComponent<BlurOptimized> ().enabled = isShowing;
			xRay.GetComponent<BlurOptimized> ().enabled = isShowing;
			hud.SetActive (!isShowing);
		}

		if (isShowing) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Time.timeScale = 0.0f;
			//playerCam.GetComponent<BlurOptimized> ().blurSize = Mathf.Lerp (0.0f, 3.0f, Time.deltaTime * speed);
			//xRay.GetComponent<BlurOptimized> ().blurSize = Mathf.Lerp (0.0f, 3.0f, Time.deltaTime * speed);
		}
		else {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Time.timeScale = 1.0f;
			//playerCam.GetComponent<BlurOptimized> ().blurSize = Mathf.Lerp (3.0f, 0.0f, Time.deltaTime * speed);
			//xRay.GetComponent<BlurOptimized> ().blurSize = Mathf.Lerp (3.0f, 0.0f, Time.deltaTime * speed);

			//pausecam.transform.position = playerCam.transform.position;
			//pausecam.transform.rotation = playerCam.transform.rotation;
		}
	}
}
