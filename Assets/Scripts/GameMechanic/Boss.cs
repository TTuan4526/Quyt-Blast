using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	public enum BossState{idle, move, patrol, death, skill1, skill2, skill3}
	
	[SerializeField] protected int health;
	[SerializeField] protected GameObject[] meteors;
    
	[HideInInspector] public bool isDeath = false;
    
	public virtual void GetDame()
	{
		health--;
	}
}
