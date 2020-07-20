using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
	private Button button;
	public string LevelName;
	private void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		if (LevelName == "Lobby")
		{
			SceneManager.LoadScene(LevelName);
		}
		LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
		switch (levelStatus)
		{
			case LevelStatus.Locked:
				Debug.Log("Cant play this level till you unlock it");
				break;
			case LevelStatus.Unlocked:
				SceneManager.LoadScene(LevelName);
				break;
			case LevelStatus.Completed:
				SceneManager.LoadScene(LevelName);
				break;
		}
	}
}
