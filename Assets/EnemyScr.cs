using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnemyScr : MonoBehaviour
{
	public float speed = 2f;  

	void Update()
	{
		// Move the enemy to the left at the specified speed
		transform.Translate(Vector3.left * speed * Time.deltaTime);
	}

	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.name.StartsWith("player"))
		{
			// Load the GameOver scene
			FindObjectOfType<GameManagerScript>().GameOver();

		}
	}
}
