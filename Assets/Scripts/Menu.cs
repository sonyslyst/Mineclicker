using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	public GameObject Level2;

	void Start () {
		if (PlayerPrefs.HasKey ("Gold")) {
			var gold = PlayerPrefs.GetFloat ("Gold");
			if (gold > 30000000) {
				Level2 = GameObject.Find ("Level2");
				var button = Level2.GetComponent<Button> ();
				button.interactable = true;
			}
		}
	}
}
