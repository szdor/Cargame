using UnityEngine;
using UnityEngine.AI;

public class AICar : CarBase
{
    // Waypoint navigáció
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float waypointThreshold = 5f;

    // Sebesség és gyorsulás
    public float maxSpeed = 70f;
    public float acceleration = 10f;

    // Kanyarodás
    public float turnSpeed = 5f;

    // Agresszió szintje
    public int aggression = 1;

    // NavMeshAgent
    private NavMeshAgent navAgent;

    protected override void Start()
    {
        base.Start();

        // NavMeshAgent inicializálása
        navAgent = GetComponent<NavMeshAgent>();
        if (navAgent == null)
        {
            navAgent = gameObject.AddComponent<NavMeshAgent>();
        }
        navAgent.speed = maxSpeed;
        navAgent.acceleration = acceleration * aggression;
        navAgent.angularSpeed = turnSpeed * 10f; // Gyors reagálás a kanyarokra
        navAgent.stoppingDistance = waypointThreshold;
        navAgent.updateRotation = false; // Kézi forgatás
        navAgent.updatePosition = true;

        // Első waypoint beállítása
        if (waypoints.Length > 0)
        {
            navAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        MoveTowardsWaypoint();
        UpdateRotation();
        LimitSpeed();
    }

    protected override void HandleInput()
    {
        // Az AI autó automatikusan kezeli a mozgást, nincs kézi bemenet
    }

    protected override void Steer()
    {
        // Kanyarodás az aktuális waypoint irányába
        Vector3 targetDirection = navAgent.steeringTarget - transform.position;
        targetDirection.y = 0; 
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * turnSpeed));
    }

    private void MoveTowardsWaypoint()
    {
        // Ellenőrzőpont távolság ellenőrzése
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < waypointThreshold)
        {
            // Következő waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }

        // Mozgás irányítása
        if (rb.velocity.magnitude < maxSpeed)
        {
            Vector3 forwardForce = transform.forward * acceleration;
            rb.AddForce(forwardForce, ForceMode.Acceleration);
        }
    }

    private void UpdateRotation()
    {
        // Forgás a következő waypoint irányába
        if (navAgent.steeringTarget != Vector3.zero)
        {
            Vector3 targetDirection = navAgent.steeringTarget - transform.position;
            targetDirection.y = 0; 
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed));
        }
    }

    private void LimitSpeed()
    {
        // Sebesség korlátozása
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void SetDifficulty(string difficulty)
    {
        // Nehézségi szint beállítása
        switch (difficulty)
        {
            case "Easy":
                maxSpeed = 50f;
                acceleration = 8f;
                aggression = 1;
                break;
            case "Medium":
                maxSpeed = 70f;
                acceleration = 10f;
                aggression = 2;
                break;
            case "Hard":
                maxSpeed = 100f;
                acceleration = 15f;
                aggression = 3;
                break;
        }
        navAgent.speed = maxSpeed;
        navAgent.acceleration = acceleration * aggression;
    }
}
