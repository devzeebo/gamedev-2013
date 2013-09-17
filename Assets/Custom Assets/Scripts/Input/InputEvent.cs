using UnityEngine;
using System;

public class InputEvent {
	
	public Source source {
		get; private set;
	}
	
	public bool active;
	public Vector3 position;
	public TouchPhase phase;
	public int clickCount;
	public Vector3 deltaPosition;
    public float totalMagnitude;
	
	internal InputEvent (Source source) {
		this.source = source;
	}
	
	public enum Source {
		TOUCH, MOUSE
	}
}