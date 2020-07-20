﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
	public GameOverController gameOverController;
	private void Awake()
	{
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerController>() != null)
		{
			Debug.Log("hh");
			LevelManager.Instance.MarkCurrentLevelComplete();
			gameOverController.gameObject.SetActive(true);
		}
	}
}