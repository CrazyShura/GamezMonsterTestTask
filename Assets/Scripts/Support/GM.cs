using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
	#region Fields
	static GM instence;
	[SerializeField]
	Slider difficulty;
	[SerializeField]
	List<GameSettings> gameSettings;

	int numOfRuns;
	static GameSettings currentSettings;
	#endregion

	#region Properties
	public static GM Instance { get { return instence; } }
	public static GameSettings CurrentSettings { get { return currentSettings; } }
	public float LastRunTime;
	public int NumOfRuns { get { return numOfRuns; } }
	#endregion

	#region Methods
	private void Start()
	{
		if(instence == null)
		{
			instence = this;
		}
		else
		{
			Debug.LogError("Trying to make more then one instance of GM");
			Destroy(this);
		}
		DontDestroyOnLoad(this);

		if(PlayerPrefs.HasKey("NumOfRuns"))
		{
			numOfRuns = PlayerPrefs.GetInt("NumOfRuns");
		}
		else
		{
			Debug.LogWarning("Cant find number of runs, reseating counter");
			numOfRuns = 0;
			PlayerPrefs.SetInt("NumOfRuns", numOfRuns);
			PlayerPrefs.Save();
		}

		EventManager.StartGame.AddListener(GameStart);
		EventManager.GameOver.AddListener(GameOver);
	}

	public void NewGame()
	{
		EventManager.StartGame.Invoke((int)difficulty.value);
	}

	void GameStart(int settingsID)
	{
		numOfRuns++;
		currentSettings = gameSettings[settingsID];
		SceneManager.LoadScene("Gameplay");
	}
	void GameOver()
	{
		PlayerPrefs.SetInt("NumOfRuns", numOfRuns);
		PlayerPrefs.Save();
		SceneManager.LoadScene("GameOver");
	}

	public void ENDME()
	{
		Application.Quit();
	}
	#endregion
}
