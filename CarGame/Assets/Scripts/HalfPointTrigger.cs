using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour {

	public GameObject FinishLap;
	public GameObject HalfLap;

	void OnTriggerEnter()
	{
		FinishLap.SetActive(true);
		HalfLap.SetActive(false);
	}
}
