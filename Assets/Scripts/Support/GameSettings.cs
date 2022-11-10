using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings")]
public class GameSettings : ScriptableObject
{
	#region Properties
	public float wallSpawnRate = 10f, lvlSpeed = 1, gapSize = 1f, playerSpeed = 1f;
	public int id;
	#endregion
}
