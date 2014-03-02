using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera camera1;
	public Camera camera2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F1))
		{
			switchCamera(1);
		}
		if (Input.GetKeyDown (KeyCode.F2)) {
			switchCamera(2);
		}
	}

	public void switchCamera (int i)
	{
		switch (i) {
		case 1:
			camera1.camera.enabled = true;
			camera2.camera.enabled = false;
			break;
		case 2:
			camera2.camera.enabled = true;
			camera1.camera.enabled = false;
			break;

		}
	}
}
