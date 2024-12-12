using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapScr: MonoBehaviour
{
	public float speed = -2f;  

	void Update()
	{
		// Move the trap to the left at the specified speed
		transform.Translate(Vector3.left * speed * Time.deltaTime);
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.name.StartsWith("player"))
		{
		
			FindObjectOfType<GameManagerScript>().GameOver();

		}
	}
}




