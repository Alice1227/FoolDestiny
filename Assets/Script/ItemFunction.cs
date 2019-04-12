using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunction : MonoBehaviour
{
	public static ItemFunction instance;

	public GameObject cup;
	public GameObject table;
	public GameObject cuplid;
	public GameObject blackcover;
	public GameObject oil;
	public GameObject oil1;
	public GameObject sugar;
	public GameObject moveText;

	public ParticleSystem fireParticle;

	public AudioClip clip_CuplidAppear;
	public AudioClip clip_BlackcoverControl;
	public AudioClip clip_Burn;
	public AudioClip clip_AntBig;
	public AudioClip clip_TableBig;
	public AudioClip clip_CupFall;
	public AudioClip clip_OilAppear;
	public AudioClip clip_OilStuck;
	public AudioClip clip_AntSlow;
	public AudioClip clip_AntFast;
	public AudioClip clip_SugarFall;
	public AudioClip clip_AddSugar;

	private GameObject[] ants;
	private AudioSource source;

	void Start ()
	{
		instance = this;
		source = GetComponent<AudioSource> ();
	}

	//black
	public void Black ()
	{
		int i = Random.Range (0, 2);
		if (i == 1) {
			Debug.Log ("CuplidAppear");
			source.PlayOneShot (clip_CuplidAppear);
			cuplid.SetActive (true);
			StartCoroutine (CuplidAppear ());
		} else {
			Debug.Log ("BlackcoverControl");
			source.PlayOneShot (clip_BlackcoverControl);
			blackcover.SetActive (true);
			StartCoroutine (BlackcoverControl ());
		}
	}

	IEnumerator CuplidAppear ()
	{
		for (float i = 0; i <= 5; i += Time.deltaTime) {
			yield return 0;
		}
		cuplid.SetActive (false);
	}


	IEnumerator BlackcoverControl ()
	{
		for (float i = 0; i <= 2; i += Time.deltaTime) {
			yield return 0;
		}
		blackcover.SetActive (false);
	}
		

	//fire
	public void Fire ()
	{
		source.PlayOneShot (clip_Burn);
		int i = Random.Range (0, 2);
		if (i == 1) {
			Debug.Log ("AntBurn");
			fireParticle.Play ();
			StartCoroutine (AntBurn ());
		} else {
			Debug.Log ("CupSmall");
			StartCoroutine (CupSmall ());
		}
	}

	IEnumerator AntBurn ()
	{
		for (float i = 0; i <= 5; i += Time.deltaTime) {
			Destroy (GameObject.FindGameObjectWithTag ("enemy"));
			yield return 0;
		}
	}

	IEnumerator CupSmall ()
	{
		for (float i = 0; i <= 5; i += Time.deltaTime) {
			cup.transform.localScale += new Vector3 (0, 0, -0.001f);
			yield return 0;
		}

		if (cup.transform.localScale.z <= 0.25) {
			Debug.Log ("GameOver");
			GameManager.instance.GameOver ();
		}
	}


	//flashlight
	public void Flashlight ()
	{
		int i = Random.Range (0, 2);
		if (i == 1) {
			Debug.Log ("AntBig");
			source.PlayOneShot (clip_AntBig);
			ants = GameObject.FindGameObjectsWithTag ("enemy");
			foreach (GameObject ant in ants) {
				ant.transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f);
			}
		} else {
			Debug.Log ("TableBig");
			source.PlayOneShot (clip_TableBig);
			table.transform.localScale += new Vector3 (0.1f, 0.1f, 0);
		}
	}


	//hand
	public void Hand ()
	{
		int i = Random.Range (0, 2);
		if (i == 1) {
			Debug.Log ("CupMove");
			cup.gameObject.GetComponent<CupController> ().enabled = true;
			moveText.SetActive (true);
			StartCoroutine (CupMove ());
		} else {
			Debug.Log ("CupFall");
			source.PlayOneShot (clip_CupFall);
			cup.transform.Rotate (new Vector3 (-45, -90, 0));
			cup.transform.Translate (new Vector3 (4, 0, 0));
			StartCoroutine (CupFall ());
		}
	}

	IEnumerator CupMove ()
	{
		for (float i = 0; i <= 5; i += Time.deltaTime) {
			yield return 0;
		}
		cup.gameObject.GetComponent<CupController> ().enabled = false;
		cup.transform.position = new Vector3 (0, cup.transform.position.y, 0);
		moveText.SetActive (false);
	}

	IEnumerator CupFall ()
	{
		for (float i = 0; i <= 5; i += Time.deltaTime) {
			yield return 0;
		}
		cup.transform.Rotate (new Vector3 (0, 90, 45));
		cup.transform.Translate (new Vector3 (0, 0, -4));
	}


	//oil
	public void Oil ()
	{
		int i = Random.Range (0, 2);
		if (i == 1) {
			Debug.Log ("OilAppear");
			source.PlayOneShot (clip_OilAppear);
			oil.SetActive (true);
			StartCoroutine (OilAppear ());
		} else {
			Debug.Log ("OilStuck");
			source.PlayOneShot (clip_OilStuck);
			oil1.SetActive (true);
			ants = GameObject.FindGameObjectsWithTag ("enemy");
			foreach (GameObject ant in ants) {
				ant.GetComponent<UnityEngine.AI.NavMeshAgent> ().speed = 0;
			}
			StartCoroutine (OilStuck ());
		}
	}

	IEnumerator OilAppear ()
	{
		for (float i = 0; i <= 5; i += Time.deltaTime) {
			yield return 0;
		}
		oil.SetActive (false);
	}

	IEnumerator OilStuck ()
	{
		for (float i = 0; i <= 5; i += Time.deltaTime) {
			yield return 0;
		}
		oil1.SetActive (false);
		foreach (GameObject ant in ants) {
			ant.GetComponent<UnityEngine.AI.NavMeshAgent> ().speed = 3;
		}
	}
		

	//pill
	public void Pill ()
	{
		int i = Random.Range (0, 2);
		if (i == 1) {
			Debug.Log ("AntSlow");
			source.PlayOneShot (clip_AntSlow);
			ants = GameObject.FindGameObjectsWithTag ("enemy");
			foreach (GameObject ant in ants) {
				ant.GetComponent<UnityEngine.AI.NavMeshAgent> ().speed = 1;
			}
			StartCoroutine (SpeedChange ());
		} else {
			Debug.Log ("AntFast");
			source.PlayOneShot (clip_AntFast);
			ants = GameObject.FindGameObjectsWithTag ("enemy");
			foreach (GameObject ant in ants) {
				ant.GetComponent<UnityEngine.AI.NavMeshAgent> ().speed = 5;
			}
			StartCoroutine (SpeedChange ());
		}
	}

	IEnumerator SpeedChange ()
	{
		for (float i = 0; i <= 5; i += Time.deltaTime) {
			yield return 0;
		}
		foreach (GameObject ant in ants) {
			ant.GetComponent<UnityEngine.AI.NavMeshAgent> ().speed = 3;
		}
	}


	//sugar
	public void Sugar ()
	{
		int i = Random.Range (0, 2);
		if (i == 1) {
			Debug.Log ("SugarFall");
			source.PlayOneShot (clip_SugarFall);
			StartCoroutine (SugarFall ());
		} else {
			Debug.Log ("AddSugar");
			source.PlayOneShot (clip_AddSugar);
			Vector3 pos = new Vector3 (0, 40, 0);
			Destroy (Instantiate (sugar, pos, transform.rotation), 2);
		}
	}

	IEnumerator SugarFall ()
	{
		Vector3 pos;
		for (float i = 0; i <= 7; i += Time.deltaTime) {
			pos = new Vector3 (sugar.transform.position.x + Random.Range (-21f, 21f), 40f, sugar.transform.position.z + Random.Range (-15f, 15f));
			Destroy (Instantiate (sugar, pos, transform.rotation), 7 - i);
			yield return 0;
		}
	}
}
