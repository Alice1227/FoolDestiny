using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public float scrollWheelSpeed = 50;

	void Start ()
	{
		Camera.main.fieldOfView = 60;
	}

	void LateUpdate ()
	{
		if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
			Camera.main.fieldOfView -= Input.GetAxis ("Mouse ScrollWheel") * scrollWheelSpeed;
			if (Camera.main.fieldOfView >= 60) {
				Camera.main.fieldOfView = 60;
			} else if (Camera.main.fieldOfView <= 40) {
				Camera.main.fieldOfView = 40;
			}
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			this.transform.RotateAround (new Vector3 (0, 0, 0), Vector3.up, 45);
		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			this.transform.RotateAround (new Vector3 (0, 0, 0), Vector3.up, 45);
		}
	}
}
