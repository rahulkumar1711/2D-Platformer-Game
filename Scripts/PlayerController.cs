using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	private bool isCrouch;
	public float jump;
	public float speed;
	private bool isGround;
	private Animator animator;
	private BoxCollider2D boxCollider2D;
	private Rigidbody2D rigidbody2D;
	public float boxcrouchsizeX, boxcrouchsizeY, boxcrouchoffsetX, boxcrouchoffsetY;
	public float boxidlesizeX, boxidlesizeY, boxidleoffsetX, boxidleoffsetY;
	private void Awake()
	{
		animator = GetComponent<Animator>();
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
		animator.SetFloat("Speed", Mathf.Abs(horizontal));
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
			isGround = false;
			animator.SetBool("Jump", true);
		}
		else
		{
			animator.SetBool("Jump", false);
		}
	}
	private void MoveCharacter(float horizontal, float vertical)
	{
		Vector3 position = transform.position;
		position.x += horizontal * speed * Time.deltaTime;
		transform.position = position;

		if (vertical > 0 && isGround == true)
		{
			rigidbody2D.AddForce(Vector2.up * jump);
		}
	}
	private void PlayerIdle()
	{
		isCrouch = false;
		animator.SetBool("Crouch", isCrouch);
		boxCollider2D.size = new Vector2(boxidlesizeX, boxidlesizeY);
		boxCollider2D.offset = new Vector2(boxidleoffsetX, boxidleoffsetY);
	}
	private void PlayerCrouch()
	{
		isCrouch = true;
		animator.SetBool("Crouch", isCrouch);
		boxCollider2D.size = new Vector2(boxcrouchsizeX, boxcrouchsizeY);
		boxCollider2D.offset = new Vector2(boxcrouchoffsetX, boxcrouchoffsetY);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isGround = true;
		}
		if (collision.gameObject.tag == "DeathCondition")
		{
			StartCoroutine(RestartTheLevel(SceneManager.GetActiveScene().name));
		}
	}
	IEnumerator RestartTheLevel(string activeScene)
	{
		animator.Play("Player_Death");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(activeScene);
	}
}