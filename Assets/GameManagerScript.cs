using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
	public int score = 0; // Player's score
	public int coins = 0; // Coins collected by the player
	public float timeRemaining = 120f; // Time remaining in seconds

	public Text scoreText; // UI Text to display the score
	public Text timeText; // UI Text to display the time remaining
	public Text coinText; // UI Text to display the collected coins

	private const float maxTime = 120f; // Maximum allowed time

	void Start()
	{
		// Reset in-memory variables at the start of a level
		score = 0;
		coins = 0;
		timeRemaining = maxTime;

		// Ensure PlayerPrefs are also reset to reflect the new game state
		PlayerPrefs.SetInt("Score", score);
		PlayerPrefs.SetInt("Coins", coins);
		PlayerPrefs.Save();

		// Update UI to reflect the reset state
		UpdateUI();
	}

	void Update()
	{
		// Decrease time and update the display
		if (timeRemaining > 0)
		{
			timeRemaining -= Time.deltaTime;
			if (timeRemaining <= 0)
			{
				timeRemaining = 0;
				GameOver(); // Trigger game over when time is up
			}
			timeText.text = "Time: " + Mathf.RoundToInt(timeRemaining).ToString();
		}
	}

	// Function to update the score (called from playerScript or coinScript)
	public void AddScore(int scoreIncrease)
	{
		score += scoreIncrease;
		UpdateUI();
	}

	// Function to increase the time when the player collects a timer
	public void AddTime(float timeIncrease)
	{
		timeRemaining += timeIncrease;
		if (timeRemaining > maxTime)
		{
			timeRemaining = maxTime;
		}
		UpdateUI();
	}

	// Function to update the coin count and display
	public void AddCoins(int coinIncrease)
	{
		coins += coinIncrease;
		UpdateUI();
	}

	// Centralized UI update function
	private void UpdateUI()
	{
		if (scoreText != null)
			scoreText.text = "Score: " + score.ToString();

		if (timeText != null)
			timeText.text = "Time: " + Mathf.RoundToInt(timeRemaining).ToString();

		if (coinText != null)
			coinText.text = "Coins: " + coins.ToString();
	}

	public void GameOver()
	{
		Debug.Log("Game Over Called");
		Debug.Log("Saving Score: " + score);
		Debug.Log("Saving Coins: " + coins);

		// Save score and coins to PlayerPrefs for the GameOver screen
		PlayerPrefs.SetInt("Score", score);
		PlayerPrefs.SetInt("Coins", coins);
		PlayerPrefs.Save(); // Ensure data is saved immediately

		// Save the current level name to PlayerPrefs so we can reload it
		string currentLevel = SceneManager.GetActiveScene().name;
		PlayerPrefs.SetString("LastPlayedLevel", currentLevel);

		// Load the GameOver scene
		SceneManager.LoadScene("gameover");
	}

	// Function to restart the game (reload the current scene)
	public void RestartGame()
	{
		// Reload the last played level from PlayerPrefs
		string lastPlayedLevel = PlayerPrefs.GetString("LastPlayedLevel", "Level1"); // Default to "Level1" if not found
		Debug.Log("Restarting level: " + lastPlayedLevel);

		// Reset PlayerPrefs for the new game state
		PlayerPrefs.SetInt("Score", 0);
		PlayerPrefs.SetInt("Coins", 0);
		PlayerPrefs.Save();

		// Load the last played level
		SceneManager.LoadScene(lastPlayedLevel);
	}
}
