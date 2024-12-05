using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	
	public GameObject lapTimer;
	public GameObject carControl;
	void Start () {
		StartCoroutine(Count());
	}
	
	IEnumerator Count()
	{
		lapTimer.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		lapTimer.SetActive(true);
		carControl.SetActive(true);
    }
}
