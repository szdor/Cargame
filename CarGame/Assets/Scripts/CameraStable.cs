using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour {

	public GameObject Car;
	public float x;
	public float y;
	public float z;
	
	// Update is called once per frame
	void Update () {
		x = Car.transform.eulerAngles.x;
		y = Car.transform.eulerAngles.y;
		z = Car.transform.eulerAngles.z;
		transform.eulerAngles = new Vector3(x-x,y-y,z-z);
	}
}
