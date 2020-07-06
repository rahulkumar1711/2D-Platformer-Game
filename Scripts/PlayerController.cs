using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private bool crouch;
	public float jump;
	public float speed;
	public Animator anim;
	private BoxCollider2D boxCollider2D;
	private Rigidbody2D rigidbody2D;
	public float boxcrouchsizeX, boxcrouchsizeY, boxcrouchoffsetX, boxcrouchoffsetY;
	public float boxidlesizeX, boxidlesizeY, boxidleoffsetX, boxidleoffsetY;
	private void Awake()
	{
		boxCollider2D = GetComponent<BoxCollider2D>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		MoveCharacter(horizontal, vertical);
		PlayerMovementanimation(horizontal, vertical);

		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			PlayerCrouch();
		}
		if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			PlayerIdle();
		}
	}
	private void PlayerMovementanimation(float horizontal, float vertical)
	{
		anim.SetFloat("Speed", Mathf.Abs(horizontal));
		Vector3 scale = transform.localScale;
		if (horizontal < 0)
		{
			scale.x = -1f * Mathf.Abs(scale.x);
		}
		else if (horizontal > 0)
		{
			scale.x = Mathf.Abs(scale.x);
		}
		transform.localScale = scale;

		if (vertical > 0)
		{
			anim.SetBool("Jump", true);
		}
		else
		{
			anim.SetBool("Jump", false);
		}
	}

	private void MoveCharacter(float horizontal, float vertical)
	{
		Vector3 position = transform.position;
		position.x += horizontal * speed * Time.deltaTime;
		transform.position = position;
		Debug.Log(transform.position);

		if (vertical > 0)
		{
			rigidbody2D.AddForce(Vector2.up * jump);
		}
	}
	private void PlayerIdle()
	{
		anim.Play("Player_Idle");
		boxCollider2D.size = new Vector2(boxidlesizeX, boxidlesizeY);
		boxCollider2D.offset = new Vector2(boxidleoffsetX, boxidleoffsetY);
	}
	private void PlayerCrouch()
	{
		if (crouch == false)
		{
			crouch = true;
		}
		anim.SetBool("Crouch", crouch);
		if (anim.GetBool("Crouch"))
		{
			crouch = false;
			anim.Play("Player_Crouch");
			boxCollider2D.size = new Vector2(boxcrouchsizeX, boxcrouchsizeY);
			boxCollider2D.offset = new Vector2(boxcrouchoffsetX, boxcrouchoffsetY);
		}
		anim.SetBool("Crouch", crouch);
	}
}
