using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsScr : MonoBehaviour
{
	public float speed = 2f; 
	void Start()
	{


	}

	void Update()
	{
		// Move the coin to the left
		transform.Translate(Vector3.left * speed * Time.deltaTime);

		// Destroy the coin if it moves off-screen
		if (transform.position.x < -10f)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.name.StartsWith("player"))
		{
			
			GameManagerScript gameManager = FindObjectOfType<GameManagerScript>();
			if (gameManager != null)
			{
				gameManager.AddCoins(1); // Increment the coin count
			}
			else
			{
				Debug.LogError("GameManagerScript not found in the scene.");
			}

			// Destroy the coin
			Destroy(gameObject);
		}
	}
}
