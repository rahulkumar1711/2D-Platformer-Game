using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Player on "+collision.gameObject.name);
	}
}
