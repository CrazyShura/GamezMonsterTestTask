using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	#region Feilds
	[SerializeField]
	GameObject player ,wall;
	[SerializeField]
	float wallSpawnRate = 10f, lvlSpeed = 1, gapSize = 1f;
	[SerializeField]
	int width = 18, height = 10;

	float floorSpawnTime, wallSpawnTimer;
	#endregion

	#region Properties

	#endregion

	#region Methods
	private void Awake()
	{
		Setup(GM.CurrentSettings);
		GameObject temp = Instantiate(player);
		temp.transform.position = new Vector3(-7, 0, 0);
	}
	public void Setup(GameSettings settings)
	{
		wallSpawnRate = settings.wallSpawnRate;
		lvlSpeed = settings.lvlSpeed;
		gapSize = settings.gapSize;
		wallSpawnTimer = wallSpawnRate - 5;
		for (int i = -width / 2; i < width / 2 + 1; i++)
		{
			SpawnWall(i, height / 2);
			SpawnWall(i, -height / 2);
		}
	}

	void SpawnWall(float x, float y, float size = 1)
	{
		GameObject temp = Instantiate(wall);
		temp.transform.position = new Vector2(x, y);
		temp.transform.parent = transform;
		Wall wallScript = temp.GetComponent<Wall>();
		wallScript.Setup(lvlSpeed);
		if (size != 1)
		{
			SpriteRenderer renderer = temp.GetComponent<SpriteRenderer>();
			renderer.size = new Vector2(1, size);
			BoxCollider2D collider = temp.GetComponent<BoxCollider2D>();
			collider.size = new Vector2(1, size);
		}
	}
	private void Update()
	{
		floorSpawnTime += Time.deltaTime * lvlSpeed;
		if (floorSpawnTime >= 1)
		{
			if (wallSpawnTimer >= wallSpawnRate)
			{
				float temp = Random.Range(3, 8);
				SpawnWall(width / 2, height / 2 - ((temp - gapSize / 2) / 2) + .5f, temp - gapSize/2);
				SpawnWall(width / 2, -height / 2 + ((11 - temp - gapSize / 2) / 2) - .5f, 11 - temp - gapSize / 2);
				floorSpawnTime -= 1;
				wallSpawnTimer = 0;
			}
			else
			{
				SpawnWall(width / 2, height / 2);
				SpawnWall(width / 2, -height / 2);
				floorSpawnTime -= 1;
				wallSpawnTimer++;
			}
		}


	}
	#endregion
}
