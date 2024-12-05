using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour {

	public static int min;
	public static int sec;
	public static float milli;
	public static float RawTime;
	public static string milliDisplay;
	public GameObject minBox;
	public GameObject secBox;
	public GameObject milliBox;
	
	// Update is called once per frame
	void Update () {
		milli += Time.deltaTime * 10;
		RawTime += Time.deltaTime;
		milliDisplay=milli.ToString("F");
		milliBox.GetComponent<Text>().text =""+ milliDisplay;
		if (milli >= 10)
		{
			milli = 0;
			sec += 1;
		}
		if (sec <= 9)
		{
			secBox.GetComponent<Text>().text = "0" + sec + ".";
		}
		else
		{
			secBox.GetComponent<Text>().text = "" + sec + ".";
		}
		if (sec >= 60)
		{
			sec= 0;
			min += 1;
		}
		if (min <= 9)
		{
			minBox.GetComponent<Text>().text="0" + min + ":";
		}
        else
        {
            minBox.GetComponent<Text>().text = "" + min + ":";
        }
    }
}
