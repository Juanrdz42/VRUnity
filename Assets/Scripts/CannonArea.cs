using UnityEngine;

public class CannonArea : MonoBehaviour
{
    bool BallIn = false;
    private Rigidbody cannonballRb = null;
    public AudioClip disparo;
    public Transform shootPoint;
    public float shootForce = 200f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CannonBall"))
        {
            Debug.Log("La bola entró");
            BallIn = true;

            cannonballRb = other.attachedRigidbody;

            if (cannonballRb == null)
                cannonballRb = other.GetComponent<Rigidbody>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CannonBall"))
        {
            Debug.Log("La bola salió");
            BallIn = false;
            cannonballRb = null;
        }
    }

    public void tryShoot()
    {
        Debug.Log("Intentando disparar. BallIn = " + BallIn + " | rb = " + (cannonballRb != null));

        if (BallIn && cannonballRb != null)
        {
            Debug.Log("La bola se disparó");

            if (SFXController.instance != null && disparo != null)
                SFXController.instance.PlaySFXAtPosition(disparo, transform.position);

            cannonballRb.isKinematic = false;
            cannonballRb.linearVelocity = Vector3.zero;
            cannonballRb.angularVelocity = Vector3.zero;

            Vector3 dir = shootPoint != null ? shootPoint.forward : transform.forward;
            cannonballRb.AddForce(dir * shootForce, ForceMode.Impulse);
        }
    }
}