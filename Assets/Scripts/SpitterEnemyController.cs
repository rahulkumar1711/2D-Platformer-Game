using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterEnemyController : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerController>() != null)
		{
			SoundsManager.Instance.Play(Sounds.EnemyAttack);
			PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
			playerController.DecreaseHealth();
		}
	}
}
