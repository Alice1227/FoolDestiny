using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour {

	public MovieTexture movTexture;

	private AudioSource audio;

	void Start()
	{
		GetComponent<RawImage>().texture = movTexture;
		audio = GetComponent<AudioSource>();
		audio.clip = movTexture.audioClip;
		movTexture.Play();
		audio.Play();
	}

	void Update() {
		if (movTexture.name == "OpeningMovie") {
			StartCoroutine (PreloadGame(audio.clip.length));
		} else {
			StartCoroutine (PreloadStart(audio.clip.length));
		} 
	}

	IEnumerator PreloadGame(float time) {
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene ("Game");
	}

	IEnumerator PreloadStart(float time) {
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene ("Start");
	}

	public void SkipOpening() {
		movTexture.Stop ();
		audio.Stop ();
		SceneManager.LoadScene ("Game");
	}
}
