using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
	
	public GameObject NextLevelPopUpMessage;
	public static bool stayOnLevel = false;
	public UnityEngine.UI.Text gpc;
	public UnityEngine.UI.Text goldDisplay;
	public float gold = 0.0f;
	public int goldperclick = 1;

	void Update(){
        //goldDisplay.text = "Gold: " + gold.ToString("F0");
		goldDisplay.text = "Gold: " + CurrencyConverter.Instance.GetCurrencyIntoStrting(gold, false, false);
        //gpc.text = goldperclick + " gold/click";
		Debug.logger.Log(string.Format("{0}", stayOnLevel));
		gpc.text = CurrencyConverter.Instance.GetCurrencyIntoStrting(goldperclick, false, true) + " gold/click";
		if (gold > 30000000 && !stayOnLevel) {
			NextLevelPopUpMessage.SetActive (true);
		}
        SaveLoad.Save();
		PlayerPrefs.SetFloat ("Gold", gold);
	}

	public void Clicked(){
		gold += goldperclick;
	}

}