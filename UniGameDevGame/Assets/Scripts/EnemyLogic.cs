using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyLogic : MonoBehaviour {

	private GameObject target;
	private float distance = 0f;
	private Vector2 home;
	public float speed = 5f;
	private Animator anim;
	private Rigidbody2D rb;
	private bool dead = false;
	public GameObject deathFlamePrefab;

	public float health = 100f;
	public float mana = 100f;
	private float BaseDamage = 10f;
	

	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag("Player");
		home = GameObject.Find("BlackKnightHome").transform.position;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		if (dead == false)
		{
			//This is the code for the movement and attack functionality of the skeleton
			#region
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("skill_1") || anim.GetCurrentAnimatorStateInfo(0).IsName("skill_2"))
				speed = 0f;
			else
				speed = 2f;
			distance = Vector2.Distance(target.transform.position, transform.position);
			//Debug.Log(distance);

			if (distance <= 6f)
				Melee();
			else if (distance > 6f && distance < 13f && mana >= 60)
				Ranged();

			

			if (distance < 15f)
				Attack();
			else if (Vector2.Distance(transform.position, home) >= 2f)
				ReturnHome();
			else
				anim.SetBool("Walking", false);
			#endregion
			
			mana = Mathf.MoveTowards(mana, 100, 5 * Time.deltaTime);
			if (health <= 0f)
			{ 
				dead = true;
				Death();
			}
		}
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
		if(!anim.GetCurrentAnimatorStateInfo(0).IsName("skill_1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("skill_2"))
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
	}

	public void SendDamage()
	{
		if (distance <= 3.5f)
			target.GetComponent<PlatformerCharacter2D>().TakeDamage(BaseDamage);
	}

	void Melee()
	{
		anim.SetTrigger("Attack");
	}

	void Ranged()
	{
		anim.SetTrigger("Magic");
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("skill_2"))
			mana -= 60;
	}

	void Death()
	{
		anim.SetTrigger("death");
		
		Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
		GetComponent<Rigidbody2D>().simulated = false;
		GetComponent<BoxCollider2D>().enabled = false;
	}

	void DeathFlame()
	{
		GameObject deathFlame = Instantiate(deathFlamePrefab, transform.position, transform.rotation);
		Destroy(deathFlame, deathFlame.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);
	}

	public void TakeDamage(float damage)
	{
		Debug.Log("Received damage");
		health -= damage;
		Vector2 dir = transform.position - target.transform.position;
		float force = 50000f;

		dir.Normalize();
		GetComponent<Rigidbody2D>().AddForce(dir * force);
	}
}
