using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Renderer rend;

    private bool buttonPressed = false;
    private Rigidbody cannonballRb = null;


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Hand"))
        {
            buttonPressed = true;
            rend.material.color = Color.green;
            Debug.Log("Botón presionado");

            TryShoot();
        }


        if (other.CompareTag("CannonBall"))
        {
            cannonballRb = other.attachedRigidbody;
            Debug.Log("Cannonball dentro del cañón");
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
        }
    }
}