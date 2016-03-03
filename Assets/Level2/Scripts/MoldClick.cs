using UnityEngine;
using System.Collections;

public class MoldClick : MonoBehaviour {

	public UnityEngine.UI.Text Mpc;
	public UnityEngine.UI.Text MoldDisplay;
	public float Mold = 0.0f;
	public int Moldperclick = 1;

	void Update(){
		//MoldDisplay.text = "Mold: " + Mold.ToString("F0");
		MoldDisplay.text = "Mold: " + CurrencyConverter.Instance.GetCurrencyIntoStrting(Mold, false, false);
		//Mpc.text = Moldperclick + " mold/click";
		Mpc.text = CurrencyConverter.Instance.GetCurrencyIntoStrting(Moldperclick, false, true) + " mold/click";
		SaveLoad.SaveLevel2();
	}

	public void Clicked(){
		Mold += Moldperclick;
	}

}