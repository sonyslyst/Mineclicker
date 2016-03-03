using UnityEngine;
using System.Collections;

public class CurrencyConverter : MonoBehaviour {

	private static CurrencyConverter instance;
	public static CurrencyConverter Instance{
		get{
			return instance;
		}
	}

	void Awake () {
		CreateInstance ();
	}

	void CreateInstance (){
		if (instance == null) {
			instance = this;
		}
	}

	public string GetCurrencyIntoStrting(float valueToConverter, bool currencyPerSec, bool currencyperClick) {
		string converted;
		if (valueToConverter >= 1000000000000) {
			converted = (valueToConverter / 1000000000000f).ToString ("f2") + " Billion"; 
		} else if (valueToConverter >= 1000000000) {
			converted = (valueToConverter / 1000000000f).ToString ("f2") + " Milliard"; 
		} else if (valueToConverter >= 1000000) {
			converted = (valueToConverter / 1000000f).ToString ("f2") + " Million"; 
		} else if (valueToConverter >= 1000) {
			converted = (valueToConverter / 1000f).ToString ("f2") + " K"; 
		} else {
			converted = "" + (int)valueToConverter;
		}

		if (currencyPerSec == true) {
			converted = converted + " gpc";
		}
		return converted;
	}
}
