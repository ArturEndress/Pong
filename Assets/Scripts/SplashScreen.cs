using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public string sceneToLoad;

    public int segParaCarregar;

	// Use this for initialization
	void Start () {

        Invoke("OpenNextScene", segParaCarregar);
	}
	
	void OpenNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
