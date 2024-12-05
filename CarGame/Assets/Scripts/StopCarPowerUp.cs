using System.Collections;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class StopCarPowerUp : PowerUp
{
    public float stopDuration = 3f;

    protected override void ApplyEffect(CarController car)
    {
        StartCoroutine(StopCar(car));
    }

    private IEnumerator StopCar(CarController car)
    {
        float originalSpeed = car.speed;
        car.speed = 0;
        yield return new WaitForSeconds(stopDuration);
        car.speed = originalSpeed;
    }
}
