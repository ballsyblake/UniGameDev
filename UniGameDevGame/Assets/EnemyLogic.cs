using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

	private GameObject target;
	private float distance = 0f;
	private Vector2 home;
	public float speed = 5f;
	private Animator anim;
	private Rigidbody2D rb;
	private bool right;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
		home = GameObject.Find("BlackKnightHome").transform.position;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		distance = Vector2.Distance(target.transform.position, transform.position);

		if (distance < 4f)
			Melee();

		if (target.transform.position.x > transform.position.x)
			right = true;
		else
			right = false;

		if (distance < 15f)
			Attack();
		else if (Vector2.Distance(transform.position, home) >= 2f)
			ReturnHome();
		else
			anim.SetBool("Walking", false);
		
	}

	void Attack()
	{
		anim.SetBool("Walking", true);
		Flip(new Vector2(target.transform.position.x, target.transform.position.y));
		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
	}

	void ReturnHome()
	{
		anim.SetBool("Walking", true);
		Flip(home);
		transform.position = Vector2.MoveTowards(transform.position,home,speed*Time.deltaTime);
	}

	void Flip(Vector2 target)
	{
		Vector3 theScale = transform.localScale;
		if (target.x < transform.position.x)
		{
			theScale.x = -0.01f;
			transform.localScale = theScale;
		}
		else if (target.x > transform.position.x)
		{
			theScale.x = 0.01f;
			transform.localScale = theScale;
		}
	}

	void Melee()
	{
		anim.SetTrigger("Attack");
	}

	void Ranged()
	{
		anim.SetTrigger("Magic");
	}
}
