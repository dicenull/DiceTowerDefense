using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
	public void OnStartButtonClick()
	{
		SceneManager.LoadScene("MainScene");
	}
}
