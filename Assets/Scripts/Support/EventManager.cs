using UnityEngine.Events;

public static class EventManager
{
	public static UnityEvent<int> StartGame = new UnityEvent<int>();
	public static UnityEvent GameOver = new UnityEvent();
}
