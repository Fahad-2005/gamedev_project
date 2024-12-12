using UnityEngine;

public class script2 : MonoBehaviour
{
	public float moveSpeed = 5f;  // Speed of movement (adjust in inspector)
	public float spawnRangeY = 3f;  // Random spawn Y position
	public float spawnDelay = 2f;  // Delay between spawn cycles

	private Vector3 spawnPosition;

	void Start()
	{
		// Randomly set spawn Y position and spawn it
		spawnPosition = new Vector3(10f, Random.Range(-spawnRangeY, spawnRangeY), 0f);
		transform.position = spawnPosition;

		// Start moving the object after spawn delay
		InvokeRepeating("MoveObject", spawnDelay, spawnDelay);
	}

	void Update()
	{
		// Move the object to the left
		transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

		// Destroy object when it goes off-screen (example)
		if (transform.position.x < -10f)
		{
			Destroy(gameObject);
		}
	}

	// Function to move the object
	//void MoveObject()
	//{
	//	// Additional logic for object movement can be added here
	//	// For now, it's simply moving to the left
	//}
}
