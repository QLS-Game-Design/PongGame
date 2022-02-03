using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
	public int leftScore = 0;
	public int rightScore = 0;

	public GameObject leftScoreLabel;
	public GameObject rightScoreLabel;
	private Rigidbody2D rb2d;

	private void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		StartCoroutine(ResetBall());
	}


	IEnumerator ResetBall()
	{
		transform.position = Vector2.zero;
		rb2d.velocity = new Vector2(0, 0);
		yield return new WaitForSeconds(2);
		float rand = Random.Range(0, 2);
		if (rand < 1)
		{
			rb2d.AddForce(new Vector2(20, -15));
		}
		else
		{
			rb2d.AddForce(new Vector2(-20, -15));
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		// This part that randomizes the bouncing from collision doesn't seem to work too well. If want to implement have to find another way

		//if (coll.collider.gameObject.name == "Paddle1" || coll.collider.gameObject.name == "Paddle2")
		//{
		//	Vector2 vel;
		//	vel.x = rb2d.velocity.x;
		//	//vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
		//	vel.y = rb2d.velocity.y;
		//	rb2d.velocity = vel;
		//}
		//else if (coll.collider.gameObject.name == "TopWall" || coll.collider.gameObject.name == "BottomWall")
		//{
		//	Vector2 vel;
		//	vel.x = rb2d.velocity.x;
		//	vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
		//	rb2d.velocity = vel;
		//}
		if (coll.collider.gameObject.name == "LeftWall")
		{
			rightScore++;
			rightScoreLabel.GetComponent<Text>().text = rightScore.ToString();
			StartCoroutine(ResetBall());
		}
		else if (coll.collider.gameObject.name == "RightWall")
		{
			leftScore++;
			leftScoreLabel.GetComponent<Text>().text = leftScore.ToString();
			StartCoroutine(ResetBall());
		}
	}
}