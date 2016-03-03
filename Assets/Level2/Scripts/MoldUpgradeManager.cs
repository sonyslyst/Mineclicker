using UnityEngine; 
using System.Collections; 
using UnityEngine.UI;

public class MoldUpgradeManager : MonoBehaviour {
	public float cost;
	public int count = 0;
	public Color affordable;
	public MoldClick click;
	public UnityEngine.UI.Text itemInfo;
	public int clickPower;
	public string itemName;
	public Color standard;
	private float baseCost;
	private Slider _slider;

	void Start(){


		baseCost = cost;
		_slider = GetComponentInChildren<Slider> ();
	}

	void Update(){
		//itemInfo.text = itemName + " (" + count + ")" + "\nCost: " + cost + "\nPower: " + clickPower + "/s";
		itemInfo.text = itemName + " (" + count + ")" + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoStrting(Mathf.Round (cost), false, false) + "\nPower: +" + clickPower + "/s";

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

	public void PurchasedUpgrade(){
		if (click.Mold >= cost) {
			Debug.logger.Log(string.Format("Cost {0}", cost));
			click.Mold -= cost;
			count += 1;
			click.Moldperclick += clickPower;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.70f, count));
		}
	}

}
