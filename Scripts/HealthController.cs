using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
	public GameObject[] hearts;
	public void UpdateLives(int h)
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			if (i < h)
			{
				hearts[i].SetActive(true);
			}
			else
			{
				hearts[i].SetActive(false);
			}
		}
	}

	public int GetHealthLength()
	{
		return hearts.Length;
	}
}
