using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private bool crouch;
	private bool playerJump;
	public Animator anim;
	public BoxCollider2D boxCollider2D;

	private void Awake()
	{
		boxCollider2D = GetComponent<BoxCollider2D>();
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Player on " + collision.gameObject.name);
	}
	private void Update()
	{
		float speed = Input.GetAxisRaw("Horizontal");
		float jump = Input.GetAxisRaw("Vertical");

		anim.SetFloat("Speed", Mathf.Abs(speed));
		if (anim.GetFloat("Speed")==1f)
		{
			boxCollider2D.size = new Vector2(1.7f, 2f);
			boxCollider2D.offset = new Vector2(0.1f, 1f);
		}
		if (anim.GetFloat("Speed") == 0f)
		{
		boxCollider2D.size = new Vector2(0.6f, 2.1f);
		boxCollider2D.offset = new Vector2(0f, 1f);
		}
		Vector3 scale = transform.localScale;
		if (speed < 0)
		{
			scale.x = -1f * Mathf.Abs(scale.x);
		}
		else if (speed > 0)
		{
			scale.x = Mathf.Abs(scale.x);
		}

		transform.localScale = scale;

		if (jump > 0)
		{
			PlayerJump();
			anim.SetBool("Jump", playerJump);
			if (anim.GetBool("Jump"))
			{
				playerJump = false;
				anim.Play("Player_Jump");
			}
			anim.SetBool("Jump", playerJump);
		}

		if (Input.GetKey(KeyCode.LeftControl))
		{
			CrouchThePlayer();
			anim.SetBool("Crouch", crouch);
			if (anim.GetBool("Crouch"))
			{
				crouch = false;
				anim.Play("Player_Crouch");
				boxCollider2D.size = new Vector2(0.9f, 1.3f);
				boxCollider2D.offset = new Vector2(-0.1f, 0.6f); 
			}
			anim.SetBool("Crouch", crouch);
		}
	}

	private void PlayerJump()
	{
		if (playerJump == false)
		{
			playerJump = true;
		}
	}

	private void CrouchThePlayer()
	{
		if (crouch == false)
		{
			crouch = true;
		}
	}
}
