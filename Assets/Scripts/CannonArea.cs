using Unity.VisualScripting;
using UnityEngine;

public class CannonArea : MonoBehaviour
{
    bool BallIn = false;
    private Rigidbody cannonballRb = null;
    public AudioClip disparo;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("CannonBall"))
        {
            Debug.Log("La bola entró");
            BallIn = true;

            cannonballRb = other.attachedRigidbody;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CannonBall"))
        {
            Debug.Log("La bola salió");
            BallIn = false;
        }
    }

    public void tryShoot()
    {
        if (BallIn)
        {
            Debug.Log("La bola se disparó");
            SFXController.instance.PlaySFXAtPosition(disparo, transform.position);
            cannonballRb.AddForce(-transform.forward * 35f, ForceMode.Impulse);
        }
    }

}
