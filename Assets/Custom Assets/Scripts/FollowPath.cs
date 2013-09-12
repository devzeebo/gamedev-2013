using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {
	
	[HideInInspector]
	public float time;
	
	PathMovement stream;
	bool following;
	int atNode;
	
	int count;
	
	[HideInInspector]
	public bool end;
	
	void Start () {
		end = false;
		
		SetFollowingPath(Timer.GetInstance().Path);
	}
	
	void Update () {
		
		if (!end)
		{
			if (stream.finished)
			{
				end = true;
				Destroy(gameObject);
			}
		}
	}
	
	public void SetFollowingPath(GameObject path)
	{
		stream = GetComponent<PathMovement>();
		
		List<Vector3> nodes = new List<Vector3>();
		//for (int i = 0; i < path.GetComponent<NodeList>().Nodes.Length; i++)
		//{
		//	nodes.Add(path.GetComponent<NodeList>().Nodes[i].transform.position);
		//}
		
		nodes.Add(path.GetComponent<NodeList>().Nodes[0].transform.position);
		nodes.Add(path.GetComponent<NodeList>().Nodes[1].transform.position);
		nodes.Add(path.GetComponent<NodeList>().Nodes[2].transform.position);
		
		end = false;
		stream.Set(nodes, 0.04f, 0.5f);
	}
}