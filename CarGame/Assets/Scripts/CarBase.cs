using UnityEngine;

public abstract class CarBase : MonoBehaviour
{
    // Alap fizikai komponensek
    protected Rigidbody rb;
    public float mass = 1200f;
    public float drag = 0.1f;
    public float angularDrag = 0.05f;

    // Kerékmechanika
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public Transform frontLeftVisual;
    public Transform frontRightVisual;
    public Transform rearLeftVisual;
    public Transform rearRightVisual;

    // Motorvezérlés
    public float motorForce = 1500f;
    public float brakeForce = 3000f;
    protected float currentBrakeForce = 0f;

    // Légellenállás
    public float airResistance = 2.5f;

    // Absztrakt vezérlési metódusok
    protected abstract void HandleInput();
    protected abstract void Steer();

    // Alap élettartam kezelő függvények
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.mass = mass;
        rb.drag = drag;
        rb.angularDrag = angularDrag;
        rb.useGravity = true;
    }

    protected virtual void FixedUpdate()
    {
        HandleInput();
        Steer();
        UpdateVisuals();
    }

    protected void ApplyBraking()
    {
        frontLeftWheel.brakeTorque = currentBrakeForce;
        frontRightWheel.brakeTorque = currentBrakeForce;
        rearLeftWheel.brakeTorque = currentBrakeForce;
        rearRightWheel.brakeTorque = currentBrakeForce;
    }

    protected void UpdateVisuals()
    {
        UpdateWheelVisual(frontLeftWheel, frontLeftVisual);
        UpdateWheelVisual(frontRightWheel, frontRightVisual);
        UpdateWheelVisual(rearLeftWheel, rearLeftVisual);
        UpdateWheelVisual(rearRightWheel, rearRightVisual);
    }

    private void UpdateWheelVisual(WheelCollider collider, Transform visual)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visual.position = position;
        visual.rotation = rotation;
    }
}
