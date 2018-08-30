using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {

	private float damage = 5f;
	private bool attacked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.tag == "Player" && !attacked)
		{
			collision.GetComponent<PlatformerCharacter2D>().TakeDamage(damage);
			attacked = true;
		}
	}

	private void OnDestroy()
	{
		attacked = false;
	}
}
