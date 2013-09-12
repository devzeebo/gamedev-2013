using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	static Timer instance;
	
	public GameObject StartPosition;
	public GameObject Path;
	
	public GameObject enemy;
	public float time;
	
	void Start () {
		instance = this;
		InvokeRepeating("Create", 0f, time);
	}
	
	void Update () {
	}
	
	void Create()
	{
		GameObject createdEnemy = (GameObject)Instantiate(enemy, StartPosition.transform.position, StartPosition.transform.rotation);
	}
	
	public static Timer GetInstance()
	{
		return instance;
	}
}