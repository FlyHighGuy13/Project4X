using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class PlanarCameraMovement : MonoBehaviour {
 	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public float mSpeed = 10.0f;
	void Update()
	{
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(mSpeed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-mSpeed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,0,-mSpeed * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,0,mSpeed * Time.deltaTime));
		}
	}
}

