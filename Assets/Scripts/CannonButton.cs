using UnityEngine;

public class CannonButton : MonoBehaviour
{
    public Renderer rend;
    public AudioClip cannonShot;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            rend.material.color = Color.green;
            SFXController.instance.PlaySFXAtPosition(cannonShot, transform.position);
        }
    }
    
     void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            rend.material.color = Color.red;
        }
    }
}
