using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f; // Alap sebesség
    public float turnSpeed = 50f; // Fordulási sebesség

    void Update()
    {
        // Autó mozgása
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.Translate(0, 0, move); // Előre-hátra mozgás
        transform.Rotate(0, turn, 0);   // Fordulás
    }
}
