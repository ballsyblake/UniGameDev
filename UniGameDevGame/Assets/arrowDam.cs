using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Hit");
            collision.collider.GetComponent<EnemyLogic>().TakeDamage(5f);
            Destroy(this);
        }
    }
}
