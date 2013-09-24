using UnityEngine;
using System.Collections;

public class FoodPile : MonoBehaviour {
	
	public int FoodAmount;
	
	public GameObject[] foods;
	
	void Start () {
		SpawnFood();
	}
	
	void Update () {
	}
	
	void SpawnFood()
	{
		SphereCollider region = GetComponent<SphereCollider>();
		
		for (int i = 0; i < FoodAmount; i++)
		{
			int foodNum = Random.Range(0, foods.Length);
			
			Vector3 position = new Vector3(Random.Range(-region.radius, region.radius), Random.Range(-region.radius, region.radius), Random.Range(-region.radius, region.radius));
			position += transform.position;
			
			Instantiate(foods[foodNum], position, Quaternion.identity);
		}
	}
}