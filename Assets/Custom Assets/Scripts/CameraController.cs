using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float speed;
	
	void Start () {
	
	}
	
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			Move(touchDeltaPosition);
		}
	}
	
	void Move(Vector2 push)
	{
		transform.Translate(-push.x * speed, -push.y * speed, 0);
	}
}
