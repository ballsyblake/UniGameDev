using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimits : MonoBehaviour {

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public Collider LeftWall;
    public Collider RightWall;
    public Collider TopWall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), 
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), 
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
        
	}
}
