using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
	public Button buttonRestart;
	private void Awake()
	{
		buttonRestart.onClick.AddListener(() => RelodLevel());
	}

	private void RelodLevel()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex);
	}

	public void PlayerDied()
	{
		gameObject.SetActive(true);
	}
}
