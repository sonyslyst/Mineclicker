using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class RunSaveLoad : MonoBehaviour {
    public void OnClickSave() {
        SaveLoad.Save();
    }
    public void OnClickLoad()
    {
        SaveLoad.Load();
    }
}