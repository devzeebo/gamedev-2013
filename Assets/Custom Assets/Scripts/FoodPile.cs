using UnityEngine;
using System.Collections.Generic;

public class FoodPile : MonoBehaviour {
	
	public int FoodAmount;
	
	public List<GameObject> foods;

	[HideInInspector]
	public List<GameObject> FoodObjects;

	void Start () {
		FoodObjects = new List<GameObject>();

		SpawnFood();
	}
	
	void Update () {
	}
	
	void SpawnFood()
	{
		SphereCollider region = GetComponent<SphereCollider>();
		
		for (int i = 0; i < FoodAmount; i++)
		{
			int foodNum = Random.Range(0, foods.Count);
			
			Vector3 position = new Vector3(Random.Range(-region.radius, region.radius), 0, Random.Range(-region.radius, region.radius));
			position += transform.position;
			
			FoodObjects.Add((GameObject)Instantiate(foods[foodNum], position, Quaternion.identity));
		}
	}
}