using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverSupport : MonoBehaviour
{
	#region Fields
	[SerializeField]
	Slider difficulty;
	[SerializeField]
	TextMeshProUGUI time,runs;
	#endregion

	#region Methods
	private void Start()
	{
		difficulty.value = GM.CurrentSettings.id;
		time.text = GM.Instance.LastRunTime.ToString("0.000");
		runs.text = GM.Instance.NumOfRuns.ToString();
	}

	public void StartAgain()
	{
		EventManager.StartGame.Invoke((int)difficulty.value);
	}

	public void ENDME()
	{
		GM.Instance.ENDME();
	}
	#endregion
}
