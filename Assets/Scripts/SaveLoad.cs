using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;

public static class SaveLoad
{
    //it's static so we can call it from anywhere
    public static void Save()
    {

		//Level1
        var itemManager = Object.FindObjectsOfType(typeof(ItemManager)) as ItemManager[];
        List<ItemManagerValues> ItemValueList = new List<ItemManagerValues>(from x in itemManager
                                                                            select new ItemManagerValues
                                                                            {
                                                                                //affordable = x.affordable,
                                                                                cost = x.cost,
                                                                                count = x.count,
                                                                                itemName = x.itemName,
                                                                                tickValue = x.tickValue
                                                                            });
		ItemValueList.Add (new ItemManagerValues() {
			itemName = "stayOnLevel",
			count = Click.stayOnLevel? 1 : 0
		});

        var upgradeManagers = Object.FindObjectsOfType(typeof(UpgradeManager)) as UpgradeManager[];
        List<UpgradeManagerValues> UpgradeValueList = new List<UpgradeManagerValues>(from x in upgradeManagers
                                                                                     select new UpgradeManagerValues()
                                                                                     {
                                                                                         //affordable = x.affordable,
                                                                                         cost = x.cost,
                                                                                         count = x.count,
                                                                                         itemName = x.itemName,
                                                                                         gold = x.click.gold,
                                                                                         goldperclick = x.click.goldperclick,
                                                                                         clickPower = x.clickPower
                                                                                     });

        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        //Level1
		FileStream Upgradefile = File.Create(Application.persistentDataPath + "/savedUpgadeList.dat"); //you can call it anything you want
        bf.Serialize(Upgradefile, UpgradeValueList);
        Upgradefile.Close();

        FileStream Itemfile = File.Create(Application.persistentDataPath + "/savedItemsList.dat"); //you can call it anything you want
        bf.Serialize(Itemfile, ItemValueList);
        Itemfile.Close();
    }

	public static void SaveLevel2()
	{
		
		//Level2
		var MolditemManager = Object.FindObjectsOfType(typeof(MoldItemManager)) as MoldItemManager[];
		List<MoldItemManagerValues> MoldItemValueList = new List<MoldItemManagerValues>(from x in MolditemManager
			select new MoldItemManagerValues
			{
				//affordable = x.affordable,
				cost = x.cost,
				count = x.count,
				itemName = x.itemName,
				tickValue = x.tickValue
			});

		var MoldupgradeManagers = Object.FindObjectsOfType(typeof(MoldUpgradeManager)) as MoldUpgradeManager[];
		List<MoldUpgradeManagerValues> MoldUpgradeValueList = new List<MoldUpgradeManagerValues>(from x in MoldupgradeManagers
			select new MoldUpgradeManagerValues()
			{
				//affordable = x.affordable,
				cost = x.cost,
				count = x.count,
				itemName = x.itemName,
				mold = x.click.Mold,
				moldperclick = x.click.Moldperclick,
				clickPower = x.clickPower
			});
		
		BinaryFormatter bf = new BinaryFormatter();

		//Level2
		FileStream MoldUpgradefile = File.Create(Application.persistentDataPath + "/savedMoldUpgadeList.dat"); //you can call it anything you want
		bf.Serialize(MoldUpgradefile, MoldUpgradeValueList);
		MoldUpgradefile.Close();

		FileStream MoldItemfile = File.Create(Application.persistentDataPath + "/savedMoldItemsList.dat"); //you can call it anything you want
		bf.Serialize(MoldItemfile, MoldItemValueList);
		MoldItemfile.Close();
	}

    public static void Load()
	//level1
	{
		if (File.Exists (Application.persistentDataPath + "/savedUpgadeList.dat")) {
			BinaryFormatter Upgradebf = new BinaryFormatter ();
			FileStream Upgradefile = File.Open (Application.persistentDataPath + "/savedUpgadeList.dat", FileMode.Open);
			var loadedUpgradeManagerValues = (List<UpgradeManagerValues>)Upgradebf.Deserialize (Upgradefile);
			var existingUpgradeManagers = Object.FindObjectsOfType (typeof(UpgradeManager)) as UpgradeManager[];
			foreach (var loadedUmv in loadedUpgradeManagerValues) {
				foreach (var existingUm in existingUpgradeManagers) {
					if (loadedUmv.itemName == existingUm.itemName) {
						existingUm.count = loadedUmv.count;
						existingUm.cost = loadedUmv.cost;
						existingUm.clickPower = loadedUmv.clickPower;
						existingUm.click.gold = loadedUmv.gold;
						existingUm.click.goldperclick = loadedUmv.goldperclick;
						//existingUm.affordable = loadedUmv.affordable;
						break;
					}
				}
			}
			Upgradefile.Close ();
		}

		if (File.Exists (Application.persistentDataPath + "/savedItemsList.dat")) {
			BinaryFormatter Itembf = new BinaryFormatter ();
			FileStream Itemfile = File.Open (Application.persistentDataPath + "/savedItemsList.dat", FileMode.Open);
			var loadedItemManager = (List<ItemManagerValues>)Itembf.Deserialize (Itemfile);
			var existingItemManger = Object.FindObjectsOfType (typeof(ItemManager)) as ItemManager[];
			foreach (var loadedUmv in loadedItemManager) {
				if (loadedUmv.itemName == "stayOnLevel") {
					Click.stayOnLevel = loadedUmv.count == 1;
					continue;
				} 
				foreach (var existingUm in existingItemManger) {
					if (loadedUmv.itemName == existingUm.itemName) {
						existingUm.count = loadedUmv.count;
						existingUm.cost = loadedUmv.cost;
						existingUm.tickValue = loadedUmv.tickValue;
						//existingUm.affordable = loadedUmv.affordable;
						break;
					}
				}
			}
			Itemfile.Close ();
		}
}

	public static void LoadLevel2()
	{
		if (File.Exists (Application.persistentDataPath + "/savedMoldUpgadeList.dat")) {
			BinaryFormatter MoldUpgradebf = new BinaryFormatter ();
			FileStream MoldUpgradefile = File.Open (Application.persistentDataPath + "/savedMoldUpgadeList.dat", FileMode.Open);
			var loadedMoldUpgradeManagerValues = (List<MoldUpgradeManagerValues>)MoldUpgradebf.Deserialize (MoldUpgradefile);
			var existingMoldUpgradeManagers = Object.FindObjectsOfType (typeof(MoldUpgradeManager)) as MoldUpgradeManager[];
			foreach (var loadedMoldUmv in loadedMoldUpgradeManagerValues) {
				foreach (var existingMoldUm in existingMoldUpgradeManagers) {
					if (loadedMoldUmv.itemName == existingMoldUm.itemName) {
						existingMoldUm.count = loadedMoldUmv.count;
						existingMoldUm.cost = loadedMoldUmv.cost;
						existingMoldUm.clickPower = loadedMoldUmv.clickPower;
						existingMoldUm.click.Mold = loadedMoldUmv.mold;
						existingMoldUm.click.Moldperclick = loadedMoldUmv.moldperclick;
						//existingMoldUm.affordable = loadedUmv.affordable;
						break;
					}
				}
			}
			MoldUpgradefile.Close ();
		}

		if (File.Exists(Application.persistentDataPath + "/savedMoldItemsList.dat"))
		{
			BinaryFormatter MoldItembf = new BinaryFormatter();
			FileStream MoldItemfile = File.Open(Application.persistentDataPath + "/savedMoldItemsList.dat", FileMode.Open);
			var loadedMoldItemManager = (List<MoldItemManagerValues>)MoldItembf.Deserialize(MoldItemfile);
			var existingMoldItemManger = Object.FindObjectsOfType(typeof(MoldItemManager)) as MoldItemManager[];
			foreach (var loadedMoldUmv in loadedMoldItemManager)
			{
				foreach (var existingMoldUm in existingMoldItemManger)
				{
					if (loadedMoldUmv.itemName == existingMoldUm.itemName)
					{
						existingMoldUm.count = loadedMoldUmv.count;
						existingMoldUm.cost = loadedMoldUmv.cost;
						existingMoldUm.tickValue = loadedMoldUmv.tickValue;
						//existingMoldUm.affordable = loadedMoldUmv.affordable;
						break;
					}
				}
			}
			MoldItemfile.Close();
		}
	}
}