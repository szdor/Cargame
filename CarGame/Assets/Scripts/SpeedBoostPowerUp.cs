using System.Collections;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SpeedBoostPowerUp : PowerUp
{
    public float speedMultiplier = 2f;
    public float duration = 5f;

    protected override void ApplyEffect(CarController car)
    {
        StartCoroutine(SpeedBoost(car));
    }

    private IEnumerator SpeedBoost(CarController car)
    {
        car.speed *= speedMultiplier;
        yield return new WaitForSeconds(duration);
        car.speed /= speedMultiplier;
    }
}
