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
	public GameObject playerTrigger; //Trigger for picking up blocks
	public GameObject hud; //Main Hud Canvas
	public bool isShowing = false;
	public Button restartButton;
	public Button quitButton;
	public Button monitorButton;
	public GameObject minimapCamera;
	public GameObject minimapCameraTwo;
	public GameObject minimapCameraThree;
	public GameObject spriteCamera;
	public GameObject spriteCameraTwo;
	public GameObject spriteCameraThree;
	public GameObject RoomOneTrigger;
	public GameObject RoomTwoTrigger;
	public GameObject RoomThreeTrigger;
	public bool onLoadMenu = false;
	public bool onOptionsMenu = false;
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

		if (Display.displays.Length > 1) {
			Display.displays [1].Activate ();
			spriteCamera.SetActive (true);
			minimapCamera.SetActive (true);
		}

		/*if (Display.displays.Length > 2) {
			Display.displays [2].Activate ();
			minimapCameraTwo.SetActive (true);
			RoomOneTrigger.SetActive (false);
		}*/

		/*if (Display.displays.Length > 3) {
			Display.displays [3].Activate ();
			Display.displays [2].Activate ();
			spriteCamera.GetComponent<Camera> ().targetDisplay = 4;
			minimapCamera.GetComponent<Camera> ().targetDisplay = 4;
			minimapCameraTwo.SetActive (true);
			minimapCameraThree.SetActive (true);
			RoomOneTrigger.SetActive (false);
			RoomTwoTrigger.SetActive (false);
			RoomThreeTrigger.SetActive (false);
		}*/
	}

	// Update is called once per frame
	void Update () {

	//Debug.Log (onLoadMenu);
		
	if (CrossPlatformInputManager.GetButtonDown("Pause") && !onLoadMenu && !onOptionsMenu) {
			isShowing = !isShowing;
			menu.SetActive (isShowing);
			//pausecam.SetActive (isShowing);
			player.GetComponent<FirstPersonController>().enabled = !isShowing;
			player.GetComponent<grab>().enabled = !isShowing;
			playerCam.GetComponent<BlurOptimized> ().enabled = isShowing;
			xRay.GetComponent<BlurOptimized> ().enabled = isShowing;
			hud.SetActive (!isShowing);
		}

		if (isShowing) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			//Time.timeScale = 0.0f;
			//playerCam.GetComponent<BlurOptimized> ().blurSize = Mathf.Lerp (0.0f, 3.0f, Time.deltaTime * speed);
			//xRay.GetComponent<BlurOptimized> ().blurSize = Mathf.Lerp (0.0f, 3.0f, Time.deltaTime * speed);
		}
		else {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			//Time.timeScale = 1.0f;
			//playerCam.GetComponent<BlurOptimized> ().blurSize = Mathf.Lerp (3.0f, 0.0f, Time.deltaTime * speed);
			//xRay.GetComponent<BlurOptimized> ().blurSize = Mathf.Lerp (3.0f, 0.0f, Time.deltaTime * speed);

			//pausecam.transform.position = playerCam.transform.position;
			//pausecam.transform.rotation = playerCam.transform.rotation;
		}
	}
}
