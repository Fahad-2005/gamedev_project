using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScr : MonoBehaviour
{
	public float speed = 2f;  

	void Update()
	{
		
		transform.Translate(Vector3.left * speed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.name.StartsWith("player"))
		{
			
			GameManagerScript gameManager = FindObjectOfType<GameManagerScript>();
			if (gameManager != null)
			{
				gameManager.AddTime(5f);
			}

			// Destroy the timer object
			Destroy(gameObject);
		}
	}
}
