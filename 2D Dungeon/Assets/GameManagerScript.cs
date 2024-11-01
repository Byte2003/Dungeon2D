using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
	public static GameManagerScript instance;
	// đảm bảo static chỉ có 1 instance duy nhất tồn tại trong cả scene
	void Awake()
	{
		if (instance != null)
		{
			DestroyImmediate(this.gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public GameObject gameOverUI;
	// Start is called before the first frame update
	void Start()
	{
		if (gameOverUI == null)
		{
			gameOverUI = GameObject.FindGameObjectWithTag("GameOverUI");
		}
		if (gameOverUI != null)
		{
			gameOverUI.SetActive(false);
		}

	}

	public void GameOver()
	{
		if (gameOverUI != null)
		{
			gameOverUI.SetActive(true);
			PlayerHealth.Instance.isDead = true;
		}
	}

	public void Restart()
	{
		if (gameOverUI != null)
		{
			gameOverUI.SetActive(false);
		}
		if (PlayerHealth.Instance != null)
		{
			Destroy(PlayerHealth.Instance.gameObject);
		}
		SceneManager.LoadScene("Scene_1");
		//StartCoroutine(DeathLoadSceneRoutine());

	}

	//private IEnumerator DeathLoadSceneRoutine()
	//{
	//	yield return new WaitForSeconds(2f);
	//	if (PlayerHealth.Instance != null)
	//	{
	//		Destroy(PlayerHealth.Instance.gameObject);
	//	}
	//	//SceneManager.LoadScene("Scene_1", LoadSceneMode.Single);
	//	SceneManager.LoadScene("Scene_1");

	//}
	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
	public void Quit()
	{
		Application.Quit();

		UnityEditor.EditorApplication.isPlaying = false;
	}
}
