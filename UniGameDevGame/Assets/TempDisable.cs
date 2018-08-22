using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempDisable : MonoBehaviour {

	float currentTime = 0f;
	float limit = 0.5f;
	Image imageExist;
	

	// Use this for initialization
	void Start () {
		imageExist = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(currentTime);
		if(imageExist.enabled == false)
		{
			currentTime += Time.deltaTime;
			if(currentTime >= limit)
			{
				imageExist.enabled = true;
				currentTime = 0f;
			}
			
		}
	}

	public void Attacking()
	{
		imageExist.enabled = false;
	}
}
