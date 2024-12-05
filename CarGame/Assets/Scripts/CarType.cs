using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarType : MonoBehaviour {
	public GameObject RedBody;
	public GameObject BlueBody;
	public GameObject YellowBody;
	public int CarImport;
	void Start () {
		CarImport = CarSelection.CarType;
		if(CarImport == 1)
		{
			RedBody.SetActive(true);
		}
        if (CarImport == 2)
        {
            BlueBody.SetActive(true);
        }
    }
}
