using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(InputHandler))]
public class CameraController : MonoBehaviour {
	
	public float speed = 0.15f;

    public int MenuDelay = 1000;

    [HideInInspector]
    public InputHandler inputHandler;

    [HideInInspector]
    public Menu ActiveMenu;

	void Start () {
        inputHandler = GetComponent<InputHandler>();
	}

    WaveManager waveManager;
    InteractionGrid grid;

	void Update () {
		
		inputHandler.handleInput();

        if (waveManager == null)
        {
            waveManager = GameObject.Find("Global").GetComponent<WaveManager>();
        }
        if (grid == null)
        {
            grid = GameObject.Find("Global").GetComponent<InteractionGrid>();
        }

        if (Input.GetKeyDown(KeyCode.Return) && !waveManager.IsInvoking("Spawn"))
        {
            waveManager.Start();
        }

		foreach (InputEvent e in inputHandler.Events)
		{
			Vector3 touchPoint = Camera.main.ScreenToWorldPoint(new Vector3(e.position.x, e.position.y, 40));
			Debug.DrawLine(Camera.main.transform.position, touchPoint, Color.red);

            if (ActiveMenu != null)
            {
                if (e.phase == TouchPhase.Ended)
                {
                    grid.CreateObject(e.position);
                    ActiveMenu = null;
                }
            }
            else
            {
                if (e.phase == TouchPhase.Moved)
                {
                    Vector2 touchDeltaPosition = e.deltaPosition;
                    Move(touchDeltaPosition);
                }
                if (e.phase == TouchPhase.Stationary && Utilities.GetCurrentTimeMillis() - e.clickTime > MenuDelay)
                {
                    ActiveMenu = grid.OpenMenuAt(e.position);
                }
            }
		}
	}
	
	void Move(Vector2 push)
	{
		transform.Translate(-push.x * speed, -push.y * speed, 0);
	}

    GameObject GetTouchedObject(Vector3 vector)
    {
        RaycastHit target;
        if (Physics.Raycast(Camera.main.transform.position, (vector - Camera.main.transform.position).normalized, out target))
        {
            return target.transform.gameObject;
        }

        return null;
    }
}
