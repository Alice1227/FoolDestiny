using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupController : MonoBehaviour
{
	private bool moveState = false;
	private Vector3 target = new Vector3 ();
	private float speed = 10;

	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);////(1)
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {////(2)
			if (Input.GetMouseButtonDown (0) && hit.transform.gameObject.tag == "table") {
				moveState = true;////(3)
				target = new Vector3 (hit.point.x, 26, hit.point.z);
			}
		}
		float step = speed * Time.deltaTime;////(4)
		////(7)
		if (moveState) {////(5)
			if (Vector3.Distance (this.transform.position, target) < 0.1f) {
				moveState = false;
			}
			this.transform.position = Vector3.MoveTowards (this.transform.position, target, step);////(6)
		}
	}
}
