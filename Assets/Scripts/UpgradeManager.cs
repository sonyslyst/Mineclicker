using UnityEngine; 
using System.Collections; 
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {
    public float cost;
	public int count = 0;
    public Color affordable;
    public Click click;
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
		itemInfo.text = itemName +  " (" + count + ")" + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoStrting(Mathf.Round (cost), false, false) + "\nPower: +" + clickPower;

		/*if (click.gold >= cost) {
			GetComponent<Image> ().color = affordable;
		} else {
			GetComponent<Image>().color = standard;
		}*/
		_slider.value = click.gold / cost * 100;
		if (_slider.value >= 100) {
			GetComponent<Image> ().color = affordable;
		} else {
			GetComponent<Image>().color = standard;
		}
	}

	public void PurchasedUpgrade(){
		if (click.gold >= cost) {
			Debug.logger.Log(string.Format("Cost {0}", cost));
			click.gold -= cost;
			count += 1;
			click.goldperclick += clickPower;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.50f, count));
		}
	}

}
