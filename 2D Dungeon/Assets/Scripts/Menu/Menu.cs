using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
		if (GameManagerScript.instance != null)
		{
			GameManagerScript.instance.Restart();
		}
		SceneManager.LoadSceneAsync(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
