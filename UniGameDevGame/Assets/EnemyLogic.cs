using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

	private GameObject target;
	private float distance = 0f;
	private Vector2 home;
	public float speed = 5f;
	private Animator anim;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
		home = GameObject.Find("BlackKnightHome").transform.position;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector2.Distance(target.transform.position, transform.position);
		if(distance < 10f)
		{
			Debug.Log(speed);
			Attack();
		}
		else if(Vector2.Distance(transform.position,home) >= 2f)
		{
			ReturnHome();
		}
		else
		{
			//anim.SetTrigger("idle_1");
		}
	}

	void Attack()
	{
		anim.SetTrigger("walk");
		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		
	}

	void ReturnHome()
	{
		transform.position = Vector2.MoveTowards(transform.position,home,speed*Time.deltaTime);
	}
}
