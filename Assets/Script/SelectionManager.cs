using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
	public List<GameObject> selectionList;
	public List<GameObject> itemList;

	public GameObject SelectPanel;
	public GameObject AlertPanel;
	public GameObject ItemPanel;
	public GameObject SpawnPoint;
	public GameObject gameManager;

	public GameObject black;
	public GameObject fire;
	public GameObject flashlight;
	public GameObject hand;
	public GameObject oil;
	public GameObject pill;
	public GameObject sugar;

	private bool hasBlack;
	private bool hasFire;
	private bool hasFlashlight;
	private bool hasHand;
	private bool hasOil;
	private bool hasPill;
	private bool hasSugar;

	Graphic weaponSlot;
	Color newColor;

	void Start ()
	{
		SelectPanel.SetActive (true);
		AlertPanel.SetActive (false);
		ItemPanel.SetActive (false);
		SpawnPoint.SetActive (false);
		gameManager.SetActive (false);
	}

	public void Select (GameObject obj)
	{
		switch (obj.name) {
		case "black":
			if (!hasBlack) {
				AddItem (black);
			} else {
				RemoveItem (black);
			}
			hasBlack = !hasBlack;
			break;
		case "fire":
			if (!hasFire) {
				AddItem (fire);
			} else {
				RemoveItem (fire);
			}
			hasFire = !hasFire;
			break;
		case "flashlight":
			if (!hasFlashlight) {
				AddItem (flashlight);
			} else {
				RemoveItem (flashlight);
			}
			hasFlashlight = !hasFlashlight;
			break;
		case "hand":
			if (!hasHand) {
				AddItem (hand);
			} else {
				RemoveItem (hand);
			}
			hasHand = !hasHand;
			break;
		case "oil":
			if (!hasOil) {
				AddItem (oil);
			} else {
				RemoveItem (oil);
			}
			hasOil = !hasOil;
			break;
		case "pill":
			if (!hasPill) {
				AddItem (pill);
			} else {
				RemoveItem (pill);
			}
			hasPill = !hasPill;
			break;
		case "sugar":
			if (!hasSugar) {
				AddItem (sugar);
			} else {
				RemoveItem (sugar);
			}
			hasSugar = !hasSugar;
			break;
		default:
			break;
		}
	}

	void AddItem (GameObject item)
	{
		for (int i = 0; i < selectionList.Count; i++) {
			if (selectionList [i].transform.childCount != 0) {
				continue;
			} else {
				Transform _i = selectionList [i].gameObject.GetComponent<RectTransform> ();
				GameObject obj = (GameObject)Instantiate (item);
				obj.name = item.name;
				obj.transform.SetParent (_i);
				obj.transform.localPosition = Vector3.zero;
				break;
			}      
		}
	}

	void RemoveItem (GameObject item)
	{
		for (int i = 0; i < selectionList.Count; i++) {
			bool isHaving = selectionList [i].transform.Find (item.name);
			if (isHaving) {
				Destroy (selectionList [i].transform.Find (item.name).gameObject);
				break;
			}
		}
	}

	bool Check ()
	{
		for (int i = 0; i < selectionList.Count; i++) {
			if (selectionList [i].transform.childCount == 0) {
				return false;
			}
		}
		return true;
	}

	public void GamePlay ()
	{
		bool status = Check ();

		if (!status) {
			AlertPanel.SetActive (true);
		} else {
			SelectPanel.SetActive (false);
			ItemPanel.SetActive (true);
			SpawnPoint.SetActive (true);
			gameManager.SetActive (true);

			for (int i = 0; i < itemList.Count; i++) {			
				Transform _i = itemList [i].gameObject.GetComponent<RectTransform> ();
				GameObject obj = (GameObject)Instantiate (selectionList [i].transform.GetChild (0).gameObject);
				obj.transform.SetParent (_i);
				obj.transform.localPosition = Vector3.zero;    
			}
		}
	}

	public void CloseAlert ()
	{
		AlertPanel.SetActive (false);
	}
}