using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	private Rigidbody2D rb2d;
	private double lastInterval;
	private float velocity_x = 1.0f;
	private float velocity_y = 1.5f;
	private float speedFactor = 1.2f;
	private float maxSpeedX = 3.0f;
	private float maxSpeedY = 3.0f;
	void GoBall() {
		float rand = Random.Range (0, 2);
		if (rand < 1) {
			rb2d.AddForce (new Vector2 (200, -100));
		} else {
			rb2d.AddForce (new Vector2 (-200, 100));
		}
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		lastInterval = Time.realtimeSinceStartup;
		Invoke ("GoBall", 2);

	}

	void ResetBall() {
		rb2d.velocity = new Vector2 (0, 0);
		transform.position = Vector2.zero;
	}

	void RestartGame() {
		ResetBall ();
		Invoke ("GoBall", 1);
	}
	void Update() {
		double currentTime = Time.realtimeSinceStartup;
		velocity_x += 0.2f*((float) (currentTime-lastInterval));
		velocity_y += 0.2f*((float) (currentTime-lastInterval));
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Player")) {
			float randx = Random.Range (0, 5);
			float randy = Random.Range (0, 5);
			Vector2 vel;
			if (rb2d.velocity.x>maxSpeedX || rb2d.velocity.y>maxSpeedY) {
				speedFactor = 1;
			}
			vel.x = speedFactor*(rb2d.velocity.x + randx);
			vel.y = speedFactor*(randy + (rb2d.velocity.y / (velocity_x)) + (coll.collider.attachedRigidbody.velocity.y / (velocity_y)));
			rb2d.velocity = vel;
		}
	}

}