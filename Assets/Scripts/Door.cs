using UnityEngine;


public class Door : MonoBehaviour
{
    public float velocidadMinima = 2f;
    public AudioClip destruction;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("CannonBall"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                float velocidad = rb.linearVelocity.magnitude;

                Debug.Log("Velocidad: " + velocidad);

                if (velocidad >= velocidadMinima)
                {
                    Debug.Log("Puerta destruida!");
                    Destroy(gameObject);
                    SFXController.instance.PlaySFXAtPosition(destruction, transform.position);

                }
            }
        }
    }
}
