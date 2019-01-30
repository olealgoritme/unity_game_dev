using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour {

	
	public float min = 2f;
	public float max = 3f;
	public float speed = 1.5f;
    
	void Start () {
       
		min = transform.position.x;
		max = transform.position.x+3;
	}
   
    
	void Update () {
		transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*speed,max-min)+min, transform.position.z);
	}

}