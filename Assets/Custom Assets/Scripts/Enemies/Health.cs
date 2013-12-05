using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Health : MonoBehaviour
{
    public float maxHealth = 100;
    internal float currentHealth;
	
	public float CurrentHealth {
		get { return currentHealth; }
		set {
			currentHealth = value;
			UpdateScale();
		}
	}
	float startScale;
	
	void Start()
	{
		currentHealth = maxHealth;
        startScale = transform.parent.FindChild("healthBar").localScale.y;
	}
	
	public void UpdateScale()
	{
		Vector3 scale = transform.parent.FindChild("healthBar").localScale;
		scale.y = startScale * (currentHealth / maxHealth);
        transform.parent.FindChild("healthBar").localScale = scale;
	}
}