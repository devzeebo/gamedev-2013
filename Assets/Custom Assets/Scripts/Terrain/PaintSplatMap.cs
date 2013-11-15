using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaintSplatMap : MonoBehaviour {

    List<GameObject> Paths;

	// Use this for initialization
	void Start () {

        foreach (GameObject path in Paths)
        {
            NodeList nodes = path.GetComponent<NodeList>();

            for (int i = 1; i < nodes.Nodes.Length; i++)
            {
                
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
