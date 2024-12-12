using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverGame : MonoBehaviour
{
	public Text gameOverText;  
	public Text scoreText;     
	public Text coinText;      
	public Button restartButton; 

	private int score;         
	private int coins;         

	// Reference to the GameManager
	private GameManagerScript gameManager;

	void Start()
	{
		
		gameManager = FindObjectOfType<GameManagerScript>();

		
		score = PlayerPrefs.GetInt("Score", 0);  
		coins = PlayerPrefs.GetInt("Coins", 0);  

		
		
		if (gameOverText != null)
			gameOverText.text = "Game Over!";
		if (scoreText != null)
			scoreText.text = "Score: " + score;
		if (coinText != null)
			coinText.text = "Coins: " + coins;

		
		if (restartButton != null)
		{
			restartButton.onClick.AddListener(RestartLevel);
		}
		
	}

	// Restart the current level
	private void RestartLevel()
	{
		
		string lastPlayedLevel = PlayerPrefs.GetString("LastPlayedLevel", "Level1"); // Default to "Level1" if not found

		SceneManager.LoadScene(lastPlayedLevel);
	}
}
