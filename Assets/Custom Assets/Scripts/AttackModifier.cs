using UnityEngine;
using System.Collections;

public class AttackModifier : MonoBehaviour {
	
	
	public float damageModifier;
	public float ModifyDamage(float damage)
	{
		return damage * (1 + damageModifier);
	}
	
	public float attackSpeedModifier;
	public float ModifyAttackSpeed(float attackSpeed)
	{
		return attackSpeed / (1 + attackSpeedModifier);
	}
}
