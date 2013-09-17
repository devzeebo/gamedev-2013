using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InputHandler
{
	private static readonly int MOUSE = 10;
	
	// Touch indexes are 0-9, Mouse is 10
	private List<InputEvent> events;
	public List<InputEvent> Events {
		get { return events.FindAll(e => e.active); }
		private set { events = value; }
	}
	
	public InputHandler () {
		events = new List<InputEvent>();
		
		for (int i = 0; i < 10; i++) {
			events.Add(new InputEvent(InputEvent.Source.TOUCH));
		}
		events.Add(new InputEvent(InputEvent.Source.MOUSE));
	}
	
	public void handleInput() {
	
		if (Input.touchCount > 0) {
			
			foreach (Touch touch in Input.touches) {
				InputEvent e = events[touch.fingerId];
				e.phase = touch.phase;
				e.position = touch.position;
				e.clickCount = touch.tapCount;
				e.deltaPosition = touch.deltaPosition;
				e.active = true;
			}
			
			var results = from t in Input.touches select t.fingerId;
			for (int i = 0; i < 10; i++) {
				if (!results.Contains (i)) {
					events[i].active = false;
				}
			}
		}
		
		InputEvent me = events[MOUSE];
		if (Input.mousePresent) {
			
			if (me.phase == TouchPhase.Ended) {
				me.active = false;
				me.position = Vector3.zero;
				me.deltaPosition = Vector3.zero;
			}
			
			if (me.active) {
				me.deltaPosition = me.position - Input.mousePosition;
				
				if (me.position != Input.mousePosition) {
					me.phase = TouchPhase.Moved;
				}
				else {
					me.phase = TouchPhase.Stationary;
				}
			}
			
			if (Input.GetMouseButtonUp(0)) {
				Debug.Log(me.phase);
				me.phase = TouchPhase.Ended;
			}
			
			if (Input.GetMouseButtonDown(0)) {
					me.active = true;
					me.phase = TouchPhase.Began;
					me.deltaPosition = Vector3.zero;
			}
			
			me.position = Input.mousePosition;
		}
	}
}