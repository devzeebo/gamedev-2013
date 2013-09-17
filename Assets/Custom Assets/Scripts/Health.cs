using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Health : MonoBehaviour
{
    public float maxHealth = 100;
    internal float currentHealth = 100;
	
	float startScale;
	
	void Start()
	{
		startScale = transform.GetChild(0).localScale.y;
	}
	
	public void UpdateScale()
	{
		Vector3 scale = transform.GetChild(0).localScale;
		scale.y = startScale * (currentHealth / maxHealth);
		transform.GetChild(0).localScale = scale;
	}
}