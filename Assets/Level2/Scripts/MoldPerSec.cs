using UnityEngine;
using System.Collections;

public class MoldPerSec : MonoBehaviour{

	public UnityEngine.UI.Text MpsDisplay;
	public MoldClick Moldclick;
	public MoldItemManager[] items;

	void Start() {
		StartCoroutine (AutoTick ());
	}

	void Update() {
		//MpsDisplay.text = GetMoldPerSec () + " Mold/sec";
		MpsDisplay.text = CurrencyConverter.Instance.GetCurrencyIntoStrting(GetMoldPerSec(), false, false) + " Mold/sec";
	}

	public float GetMoldPerSec(){
		float tick = 0;
		foreach(MoldItemManager item in items) {
			tick += item.count * item.tickValue;
		}
		return tick;
	}

	public void AutoMoldPerSec() {
		Moldclick.Mold += GetMoldPerSec () / 10;
	}

	IEnumerator AutoTick() {
		while (true) {
			AutoMoldPerSec ();
			yield return new WaitForSeconds(0.1f);
		}
	}

}