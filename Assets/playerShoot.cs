using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
	public GameObject bulletPrefab; // Reference to the bullet prefab

	// Function to fire a bullet (called on button click)
	public void Fire()
	{
		Vector2 bulletPosition = transform.position;

		// Adjust the bullet's position slightly above the player's current position
		bulletPosition.y += 0.2f;

		// Instantiate the bullet
		Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
	}
}
