using UnityEngine;
using System.Collections;

public class LoopAnimation : MonoBehaviour {

	public string AnimationName;

	public float Speed;

	// Use this for initialization
	void Start () {
		animation [AnimationName].speed = Speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
