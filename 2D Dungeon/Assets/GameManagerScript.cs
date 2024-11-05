using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class GameManagerScript : MonoBehaviour
{
	public static GameManagerScript instance;
	public bool isGameOver = false;
	public GameObject gameOverUI;
	public CinemachineVirtualCamera virtualCamera;

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
		SetupCamera();

	}

	public void SetupCamera()
	{
		if (virtualCamera == null)
		{
			virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
		}

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null && virtualCamera != null)
		{
			virtualCamera.Follow = player.transform;
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
		SceneManager.LoadSceneAsync("Scene_1").completed += (AsyncOperation op) =>
		{
			SetupCamera();
		};
	}

	public void MainMenu()
	{
		isGameOver = false;
		if (gameOverUI != null)
		{
			gameOverUI.SetActive(false);
		}
		if (GameManager.Instance != null)
		{
			Destroy(GameManager.Instance.gameObject);
		}
		SceneManager.LoadScene("Menu");
	}
	public void Quit()
	{
		Application.Quit();

		UnityEditor.EditorApplication.isPlaying = false;
	}
}
