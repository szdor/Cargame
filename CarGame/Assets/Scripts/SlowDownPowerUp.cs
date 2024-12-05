using System.Collections;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SlowDownPowerUp : PowerUp
{
    public float speedReduction = 0.5f; // Mennyivel lassítjuk le az autót (arányos csökkentés)
    public float duration = 5f;        // Hatás időtartama másodpercben

    protected override void ApplyEffect(CarController car)
    {
        StartCoroutine(SlowDown(car));
    }

    private IEnumerator SlowDown(CarController car)
    {
        car.speed *= speedReduction; // Sebesség csökkentése
        yield return new WaitForSeconds(duration); // Várakozás
        car.speed /= speedReduction; // Sebesség visszaállítása
    }
}

