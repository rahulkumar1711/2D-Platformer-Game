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
	public void PlayerDied()
	{
		SoundsManager.Instance.PlayMusic(Sounds.PlayerDeath);
		gameObject.SetActive(true);
	}
	private void RelodLevel()
	{
		SoundsManager.Instance.PlayMusic(Sounds.Music);
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex);
	}
}
