using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLap : MonoBehaviour {

	public GameObject finishLapTrig;
	public GameObject halfLapTrig;
	public GameObject minDisplay;
	public GameObject secDisplay;
	public GameObject miliDisplay;
	public GameObject lapTime;
	public GameObject Counter;
	public GameObject FinishRace;
	public int Laps;
	public static float RawTime;

	void Update()
	{
		if(Laps == 1)
		{
			FinishRace.SetActive(true);
		}
	}
	void OnTriggerEnter()
	{
		Laps += 1;
		RawTime = PlayerPrefs.GetFloat("RawTime");
		if (LapTimeManager.RawTime <= RawTime)
		{
			if (LapTimeManager.sec <= 9)
			{
				secDisplay.GetComponent<Text>().text = "0" + LapTimeManager.sec + ".";
			}
			else
			{
				secDisplay.GetComponent<Text>().text = "" + LapTimeManager.sec + ".";
			}
			if (LapTimeManager.min <= 9)
			{
				minDisplay.GetComponent<Text>().text = "0" + LapTimeManager.min + ".";
			}
			else
			{
				minDisplay.GetComponent<Text>().text = "" + LapTimeManager.min + ".";
			}
			miliDisplay.GetComponent<Text>().text = "" + LapTimeManager.milli;
		}

		PlayerPrefs.SetInt("MinSave", LapTimeManager.min);
		PlayerPrefs.SetInt("SecSave", LapTimeManager.sec);
		PlayerPrefs.SetFloat("MiliSave", LapTimeManager.min);
		PlayerPrefs.SetFloat("RawTime", LapTimeManager.RawTime);
		LapTimeManager.min = 0;
		LapTimeManager.sec = 0;
		LapTimeManager.milli= 0;
		LapTimeManager.RawTime= 0;
		Counter.GetComponent<Text>().text = ""+Laps;
		halfLapTrig.SetActive(true);
		finishLapTrig.SetActive(false);
    }
}
