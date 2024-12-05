using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public abstract class PowerUp : MonoBehaviour
{
    protected abstract void ApplyEffect(CarController car);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CarController car = other.GetComponent<CarController>();
            if (car != null)
            {
                ApplyEffect(car);
            }
            Destroy(gameObject);
        }
    }
}

