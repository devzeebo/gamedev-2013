using UnityEngine;
using System.Collections;

public class Begin : MonoBehaviour {

	public GameObject tileCollider;

	void Start () {
		for (int i = 0; i < 25; i++)
		{
			for (int j = 0; j < 25; j++)
			{
				Vector3 position = new Vector3(i * 10 - 125f, 0, j * 10 - 125f);
				position.y = Terrain.activeTerrain.SampleHeight(position);
				GameObject tile = (GameObject)Instantiate(tileCollider, position, Quaternion.identity);
				tile.transform.parent = transform;
			}
		}
	}
}