using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCoin : MonoBehaviour
{
	public float speed = 2f;

	void Update()
	{
		// Move leftward with the background
		transform.Translate(Vector3.left * speed * Time.deltaTime);

		// Destroy the coin when off-screen
		if (transform.position.x < -10f)
		{
			Destroy(gameObject);
		}
	}

	//void OnTriggerEnter2D(Collider2D collision)
	//{
	//	// Check if the player's name starts with "player" (adjust as needed)
	//	if (collision.gameObject.name.StartsWith("player"))
	//	{
	//		GameManager.instance.AddScore(1); // Assuming you have an AddScore function
	//		Destroy(gameObject);
	//	}
	//}
}
