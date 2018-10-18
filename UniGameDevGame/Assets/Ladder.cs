using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    private bool onLadder = false;
    private GameObject target;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (onLadder)
        {
            if (Input.GetKeyDown("w"))
            {
                target.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
            }
            else if (Input.GetKeyDown("s"))
            {
                target.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -100));
            }
            
                
        }
	}

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onLadder = true;
            target.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            onLadder = false;
            target.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
            
    }
}
