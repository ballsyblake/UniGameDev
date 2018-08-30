using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour {

	public GameObject FirePrefab;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{
		Quaternion rotation = transform.rotation;
		rotation.z = 0;
		FirePrefab.transform.localScale = new Vector3(0.64f, 1.75f, 0f);
		GameObject fire = Instantiate(FirePrefab, transform.position, rotation);
		Destroy(fire, fire.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);
	}
}
