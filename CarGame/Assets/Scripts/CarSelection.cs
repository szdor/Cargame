using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour {

	public static int CarType;
    public GameObject Tracks;
	
	public void Car1()
	{
		CarType = 1;
        Tracks.SetActive(true);
	}
    public void Car2()
    {
        CarType = 2;
        Tracks.SetActive(true);
    }
}
