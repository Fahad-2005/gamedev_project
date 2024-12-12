using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
	private GameManagerScript gameManager;

	// Start is called before the first frame update
	void Start()
	{
		// Find the GameManagerScript instance in the scene
		gameManager = FindObjectOfType<GameManagerScript>();
		

		// Destroy the bullet after 5 seco
		Destroy(gameObject, 5f);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.Translate(0.6f, 0, 0); 
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Check if the bullet collides with an enemy object
		if (collision.gameObject.CompareTag("Enemy"))
		{
			
			Destroy(collision.gameObject);

			// Add score in GameManager when enemy is destroyed
			if (gameManager != null)
			{
				gameManager.AddScore(10); 
			}

			// Destroy the bullet
			Destroy(gameObject);
		}
	}
}
