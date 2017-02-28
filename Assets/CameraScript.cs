using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraScript : MonoBehaviour {

	public Camera mainCam;
	public Camera camera;
	public Material mat;

	void Start()
	{
		mainCam.clearStencilAfterLightingPass = true;
	}

	/*void Update()
	{
		Shader.SetGlobalMatrix("_weaponMatrix", 
		                       camera.projectionMatrix);
	}*/

}
 