using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	#region Fields
	float speed;
	#endregion

	#region Methods
	public void Setup(float Speed = 1)
	{
		speed = Speed;
	}

	private void Update()
	{
		transform.position += Vector3.left * speed * Time.deltaTime;
		if(transform.position.x < -11)
		{
			Destroy(gameObject);
		}
	}
	#endregion
}
