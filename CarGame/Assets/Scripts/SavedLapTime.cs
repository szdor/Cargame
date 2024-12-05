using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedLapTime : MonoBehaviour {

	public int Min;
	public int Sec;
	public float Milli;
	public GameObject MinDisplay;
	public GameObject SecDisplay;
	public GameObject MilliDisplay;
	void Start () {
		Min = PlayerPrefs.GetInt("MinSave");
		Sec = PlayerPrefs.GetInt("SecSave");
		Milli = PlayerPrefs.GetFloat("MilliSave");
		MinDisplay.GetComponent<Text>().text = "" + Min+":";
		SecDisplay.GetComponent<Text>().text = "" + Sec+".";
		MilliDisplay.GetComponent<Text>().text = "" + Milli;
	}
}
