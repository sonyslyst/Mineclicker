using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevels : MonoBehaviour {
	public GameObject NextLevelPopUpMessage;

    public void OnClickMenuLevel1() {
        Application.LoadLevel (1);
    }

    public void OnClickMenuLevel2() {
        Application.LoadLevel(2);
    }

    public void OnClickMenu() {
        Application.LoadLevel(0);
    }

	public void OnClickNextLevel() {
		Click.stayOnLevel = true;
		SaveLoad.Save ();
		Application.LoadLevel(2);
	}

	public void OnClickStay() {
		NextLevelPopUpMessage.SetActive (false);
		Click.stayOnLevel = true;
		SaveLoad.Save ();
	}
}
