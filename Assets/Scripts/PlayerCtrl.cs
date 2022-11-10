using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
	#region Fields
	[SerializeField]
	float gravityScale = 1f , speedChange = 15f;
	Rigidbody2D rgbd;

	float speedChangeTimer , runTime;
	#endregion

	#region Properties

	#endregion

	#region Methods
	private void Start()
	{
		rgbd = GetComponent<Rigidbody2D>();
		gravityScale = GM.CurrentSettings.playerSpeed;
	}
	private void Update()
	{
		runTime += Time.deltaTime;

		if (Input.GetKey(KeyCode.UpArrow))
		{
			rgbd.gravityScale = -1 * gravityScale;
		}
		else
		{
			rgbd.gravityScale = gravityScale;
		}

		speedChangeTimer += Time.deltaTime;
		if(speedChangeTimer >= speedChange)
		{
			gravityScale *= 1.5f;
			speedChangeTimer -= speedChange;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Wall")
		{
			GM.Instance.LastRunTime = runTime;
			EventManager.GameOver.Invoke();
		}
	}
	#endregion
}
