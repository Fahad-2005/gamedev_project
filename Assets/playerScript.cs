using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
	public GameObject bulletPrefab; // Reference to the bullet prefab
	private bool isGrounded; // Boolean to check if the player is on the ground
	private GameManagerScript gameManager; // Reference to the GameManager for updating score and time
	public AudioSource fireSound;
	public AudioSource coincollect;

	// Start is called before the first frame update
	void Start()
	{
		isGrounded = true; // Initially, the player is on the ground

		// Find the GameManagerScript instance
		gameManager = FindObjectOfType<GameManagerScript>();
	}

	// Update is called once per frame
	void Update()
	{
		// Check for fire input
		if (Input.GetKeyDown(KeyCode.F))
		{
			Fire(); // Call the fire function
		}

		// Jump when the space key is pressed or when the screen is touched (for mobile)
		if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)
		{
			Jump(); // Call the jump function
		}
	}

	// Function to fire the bullet
	public void Fire()
	{
		// Get the player's current position
		Vector2 bulletPosition = transform.position;

		// Adjust the bullet's position to spawn slightly above the player
		bulletPosition.y += 0.2f;

		// Instantiate the bullet at the calculated position
		Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
		if (fireSound != null)
		{
			fireSound.Play();
		}
	}

	// Function to handle jumping
	public void Jump()
	{
		if (isGrounded)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400));
			isGrounded = false; // Set to false as the player is now in the air
		}
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		// Handle ground collision
		if (collision.gameObject.name.StartsWith("surface"))
		{
			isGrounded = true;
		}

		// Handle coin collision
		if (collision.gameObject.name.StartsWith("coin"))
		{
			if (coincollect != null)
			{
				coincollect.Play();
			}
		}
	}
}
