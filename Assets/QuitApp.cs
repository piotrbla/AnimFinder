using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitApp : MonoBehaviour {
	public void DoQuit () {
		Application.Quit();
	}

    public void DoBack()
    {
        SceneManager.LoadScene("Main");
    }
}
