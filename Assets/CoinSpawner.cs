using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject coinPrefab;   // Coin Prefab
	public GameObject enemyPrefab;  // Enemy Prefab
	public GameObject trapPrefab;   // Trap Prefab
	public GameObject timerPrefab;  // Timer Prefab

	public float coinSpawnInterval = 7f;    // Time between spawning coins
	public float enemySpawnInterval = 14f;   // Time between spawning enemies
	public float trapSpawnInterval = 17f;    // Time between spawning traps
	public float timerSpawnInterval = 32f;   // Time between spawning timers

	private void Start()
	{
		// Start spawning all objects
		StartCoroutine(SpawnCoins());
		StartCoroutine(SpawnEnemies());
		StartCoroutine(SpawnTraps());
		StartCoroutine(SpawnTimers());
	}

	// Coroutine to spawn coins at regular intervals
	IEnumerator SpawnCoins()
	{
		while (true)
		{
			yield return new WaitForSeconds(coinSpawnInterval);

			// Instantiate the coin at a random x position
			Vector3 coinSpawnPosition = new Vector3(10f, Random.Range(-3f, 2.5f), 0f); // x = 10 for coin spawn
			Instantiate(coinPrefab, coinSpawnPosition, Quaternion.identity);
		}
	}

	// Coroutine to spawn enemies at regular intervals
	IEnumerator SpawnEnemies()
	{
		while (true)
		{
			yield return new WaitForSeconds(enemySpawnInterval);

			// Instantiate the enemy at a random x position
			Vector3 enemySpawnPosition = new Vector3(10f, Random.Range(-1.43f, 1.43f), 0f); // x = 10 for enemy spawn
			Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity);
		}
	}

	// Coroutine to spawn traps at regular intervals
	IEnumerator SpawnTraps()
	{
		while (true)
		{
			yield return new WaitForSeconds(trapSpawnInterval);

			// Instantiate the trap at a random x position
			Vector3 trapSpawnPosition = new Vector3(10f, -2.7f, 0f); // x = 10 for trap spawn
			Instantiate(trapPrefab, trapSpawnPosition, Quaternion.identity);
		}
	}

	// Coroutine to spawn timers at regular intervals
	IEnumerator SpawnTimers()
	{
		while (true)
		{
			yield return new WaitForSeconds(timerSpawnInterval);

			// Instantiate the timer at a random x position
			Vector3 timerSpawnPosition = new Vector3(10f, Random.Range(-3f, 2f), 0f); // x = 10 for timer spawn
			Instantiate(timerPrefab, timerSpawnPosition, Quaternion.identity);
		}
	}
}
