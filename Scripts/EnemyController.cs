using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private bool collision;
	public Transform startpos, endpos;
	public Rigidbody2D myRigid;
	public float speed;
	private void FixedUpdate()
	{
		Move();
		ChangeDirection();
	}

	private void Move()
	{
		myRigid.velocity = new Vector2(transform.localScale.x, 0) * speed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerController>() != null)
		{
			PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
			playerController.KillPlayer();
		}
	}
	public void ChangeDirection()
	{
		collision = Physics2D.Linecast(startpos.position, endpos.position, 1 << LayerMask.NameToLayer("Ground"));
		if (!collision)
		{
			Vector3 temp = transform.localScale;
			if (temp.x == 1f)
			{
				temp.x = -1f;
			}
			else
			{
				temp.x = 1f;
			}
			transform.localScale = temp;
		}
	}
}
