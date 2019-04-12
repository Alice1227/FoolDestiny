using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sugar : MonoBehaviour
{
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "enemy") {
			Destroy (this.gameObject);
			Destroy (col.gameObject);
		}
	}
}
