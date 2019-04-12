using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public Text timeText;
	public float count;

	private TimeSpan timeSpan;
	private string time;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		instance = this;
		count = 121;
		audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= 0) {
			count -= Time.deltaTime;
			timeSpan = TimeSpan.FromSeconds (count);
		}

		time = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
		timeText.text = time;
	}

	public void GameOver() {
		audio.Stop ();
		SceneManager.LoadScene ("BadEnd");
	}

	public void HappyEnding() {
		int num = UnityEngine.Random.Range (1, 4);
		Debug.Log (num);
		SceneManager.LoadScene ("HappyEnd_" + num.ToString ());
	}
}
