using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoldItemManager : MonoBehaviour {

	public UnityEngine.UI.Text itemInfo;
	public MoldClick click;
	public float cost;
	public int tickValue;
	public int count;
	public string itemName;
	public Color standard;
	public Color affordable;
	private float baseCost;
	private Slider _slider;
	public float Mold = 0.0f;

	void Start(){
		baseCost = cost;
		_slider = GetComponentInChildren<Slider> ();
	}

	void Update(){
		//itemInfo.text = itemName + " (" + count + ")" + "\nCost: " + cost + "\nGold: " + tickValue + "/s";
		itemInfo.text = itemName + " (" + count + ")" + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoStrting(Mathf.Round (cost), false, false) + "\nMold: " + tickValue + "/s";
		/*if (click.gold >= cost) {
			GetComponent<Image> ().color = affordable;
		} else {
			GetComponent<Image>().color = standard;
		}*/
		_slider.value = click.Mold / cost * 100;
		if (_slider.value >= 100) {
			GetComponent<Image> ().color = affordable;
		} else {
			GetComponent<Image>().color = standard;
		}
	}

	public void PurchaseItem(){
		if (click.Mold >= cost) {
			click.Mold -= cost;
			count += 1;
			cost = Mathf.Round (baseCost * Mathf.Pow (3.20f, count));
		}
	}

}