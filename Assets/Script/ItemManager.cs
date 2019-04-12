using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
	IEnumerator CDTimer (Button button)
	{
		for (float i = 0; i <= 7; i += Time.deltaTime) {
			yield return 0;
		}
		button.interactable = true;
	}

	public void Use (Button button)
	{
		button.interactable = false;
		StartCoroutine (CDTimer (button));

		GameObject obj = this.transform.GetChild (0).gameObject;

		switch (obj.name) {
		case "black(Clone)":
			ItemFunction.instance.Black ();
			break;
		case "fire(Clone)":
			ItemFunction.instance.Fire ();
			break;
		case "flashlight(Clone)":
			ItemFunction.instance.Flashlight ();
			break;
		case "hand(Clone)":
			ItemFunction.instance.Hand ();
			break;
		case "oil(Clone)":
			ItemFunction.instance.Oil ();
			break;
		case "pill(Clone)":
			ItemFunction.instance.Pill ();
			break;
		case "sugar(Clone)":
			ItemFunction.instance.Sugar ();
			break;
		default:
			break;
		}
	}
}
