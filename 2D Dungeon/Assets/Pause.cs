using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	public GameObject pauseMenu;
	public static bool isPaused;

	public static Pause instance;
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
		pauseMenu.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}

	public void PauseGame()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}
	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}
	public void RestartGame()
	{
		ResumeGame();
		if (GameManagerScript.instance != null)
		{
			GameManagerScript.instance.Restart();
		}
	}

}
