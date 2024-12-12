using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
	
	public void LoadLevel1()
	{
		SceneManager.LoadScene("level1");
	}

	
	public void LoadLevel2()
	{
		SceneManager.LoadScene("level2");
	}

	
	public void LoadLevel3()
	{
		SceneManager.LoadScene("level3");
	}

	
	public void LoadLevel4()
	{
		SceneManager.LoadScene("level4");
	}

	
	public void LoadLevel5()
	{
		SceneManager.LoadScene("level5");
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene("Mainmenu"); 
	}
}
