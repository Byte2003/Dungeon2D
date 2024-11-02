using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
	public static GameManagerScript instance;
	public bool isGameOver = false;
	public GameObject gameOverUI;

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
			isGameOver = true;
			PlayerHealth.Instance.isDead = true;
			Time.timeScale = 0f;
		}
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		isGameOver = false;
		if (gameOverUI != null)
		{
			gameOverUI.SetActive(false);
		}
		if (PlayerHealth.Instance != null)
		{
			Destroy(PlayerHealth.Instance.gameObject);
		}
		if (Stamina.Instance != null)
		{
			Stamina.Instance.ResetStamina();
		}
		if(EconomyManager.Instance != null)
		{
			EconomyManager.Instance.ResetGold();
		}
		if (Pause.instance != null)
		{
			Pause.instance.ResumeGame();
		}
		SceneManager.LoadScene("Scene_1");

	}

	public void MainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	public void Quit()
	{
		Application.Quit();

		UnityEditor.EditorApplication.isPlaying = false;
	}
}
