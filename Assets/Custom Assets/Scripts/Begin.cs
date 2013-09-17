using UnityEngine;
using System.Collections;

public class Begin : MonoBehaviour {

	public GameObject tileCollider;
	
	void Start () {
		for (int i = 0; i < 25; i++)
		{
			for (int j = 0; j < 25; j++)
			{
				GameObject tile = (GameObject)Instantiate(tileCollider, new Vector3(i * 10 - 120f, 0, j * 10 - 120f), Quaternion.identity);
				tile.transform.parent = transform;
			}
		}
	}
}