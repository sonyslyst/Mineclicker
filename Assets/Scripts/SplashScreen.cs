using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
    public float timer = 2f;
    public string levelToLoad = "level1";

    // Use this for intialzation
    void Start() {
        StartCoroutine("DisplayScene");
    }

    IEnumerator DisplayScene() {
        yield return new WaitForSeconds( timer );
        Application.LoadLevel( levelToLoad );
    }

}
