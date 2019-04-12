using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AntMove : MonoBehaviour
{

	private UnityEngine.AI.NavMeshAgent agent;
	private Transform target;

	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		GetComponent<UnityEngine.AI.NavMeshAgent> ().nextPosition = transform.position;
		target = GameObject.FindGameObjectWithTag ("target").transform;
	}

	// Update is called once per frame
	void Update ()
	{

		agent.SetDestination (target.position);

		if (GameManager.instance.count > 0) {
			if (Vector3.Distance (target.position, this.gameObject.transform.position) < 3) {
				Debug.Log ("GameOver");
				Destroy (this.gameObject);
				GameManager.instance.GameOver ();
			}
		} else {
			GameManager.instance.HappyEnding ();
		}
	}
}

