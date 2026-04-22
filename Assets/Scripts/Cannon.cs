using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Renderer rend;

    private bool buttonPressed = false;
    private Rigidbody cannonballRb = null;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró: " + other.name + " | " + other.tag);

        if (other.CompareTag("Hand"))
        {
            buttonPressed = true;
            rend.material.color = Color.green;
            Debug.Log("Botón presionado");

            TryShoot(); // 👈 IMPORTANTE
        }

        if (other.CompareTag("CannonBall"))
        {
            cannonballRb = other.attachedRigidbody;

            if (cannonballRb == null)
                cannonballRb = other.GetComponent<Rigidbody>();

            Debug.Log("Cannonball dentro del cañón");

            TryShoot(); // 👈 IMPORTANTE TAMBIÉN
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            buttonPressed = false;
            rend.material.color = Color.red;
        }

        if (other.CompareTag("CannonBall"))
        {
            cannonballRb = null;
        }
    }

    void TryShoot()
    {
        if (buttonPressed && cannonballRb != null)
        {
            Debug.Log("🔥 DISPARO DEL CAÑÓN");

            cannonballRb.AddForce(-transform.forward * 2000f, ForceMode.Impulse);

            // opcional: evitar disparo infinito
            cannonballRb = null;
        }
        else
        {
            Debug.Log("No dispara → button: " + buttonPressed + " ball: " + (cannonballRb != null));
        }
    }
}