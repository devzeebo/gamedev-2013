using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathMovement : MonoBehaviour
{
	private Vector3 defaultNormalizedPath;
	private Vector3 projectedNormalizedPath;
	private Vector3 currentNormalizedPath;
	private Vector3 velocity;
	private int wpIndex = 0;
	private float forcePower;
	private Vector3 currentForceVector = Vector3.zero;
	private float baseDrag;
	[HideInInspector]
	public List<Vector3>waypointCollection;
	
	public float speed = 1f;
	
	public bool loop;
	
	public bool faceDirection = true;
	
	[HideInInspector]
	public bool finished;
	
	[HideInInspector]
	public bool moving;
	
	// Use this for initialization
	void Start ()
	{
		moving = false;
	}
	
	public void Set(List<Vector3> path, float forcePower, float drag)
	{
		transform.position = path[0];
		waypointCollection = new List<Vector3>();
		foreach (Vector3 node in path)
		{
			waypointCollection.Add(node);
		}
		this.forcePower = forcePower;
		this.currentForceVector = Vector3.zero;
		wpIndex = 1;
		baseDrag = drag;
		defaultNormalizedPath = ((waypointCollection[wpIndex] - waypointCollection[wpIndex-1]).normalized);
		//Debug.Log("defaultNormalizedPath: "+defaultNormalizedPath.ToString());
		
		finished = false;
		
		//InvokeRepeating("Move", 0f, 0.1f);
		InvokeRepeating("Move", 0f, 0.05f);
	}
	
	public void Move()
	{
		moving = true;
		if (Vector3.Distance(waypointCollection[wpIndex], transform.position) < 0.2f)
		{
			//Debug.Log("goal reached");
			wpIndex++;
			if(wpIndex >= waypointCollection.Count)
			{
				if (loop)
				{
					wpIndex = 0;
				}
				else
				{
					finished = true;
					CancelInvoke();
					moving = false;
					return;
				}
				// end of path
			}
			defaultNormalizedPath = ((waypointCollection[wpIndex] - waypointCollection[wpIndex-1]).normalized);
		}
		currentNormalizedPath = (waypointCollection[wpIndex] - transform.position).normalized;
		currentForceVector = ((currentNormalizedPath - defaultNormalizedPath)*0.5f + currentNormalizedPath)*forcePower;
		velocity += currentForceVector;
		velocity *= (1f-baseDrag);
		transform.position += (speed * velocity);

        if (faceDirection)
        {
            gameObject.transform.FindChild("Model").forward = velocity.normalized;
        }
	}
}