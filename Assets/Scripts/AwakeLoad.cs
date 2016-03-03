using UnityEngine;
using System.Collections;

public class AwakeLoad : MonoBehaviour
{
	public GameObject NextLevelPopUpMessage;

    void Awake()
    {
		SaveLoad.Load();
		SaveLoad.LoadLevel2();
		NextLevelPopUpMessage.SetActive (false);
    }
}