using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDie : MonoBehaviour
{
	private AudioSource audio;

	// Use this for initialization
	void Start ()
	{
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButton (0) && Physics.Raycast (ray, out hit)) {
			if (hit.transform.tag == "enemy") {
				audio.Play ();
				Destroy (hit.transform.gameObject);
			}
		}
	}
}
