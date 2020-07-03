using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Animator anim;
	private void Update()
	{
		float speed = Input.GetAxisRaw("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(speed));

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
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Player on "+collision.gameObject.name);
	}
}
