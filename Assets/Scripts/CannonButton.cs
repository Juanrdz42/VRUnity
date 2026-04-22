using UnityEngine;

public class CannonButton : MonoBehaviour
{
    public Renderer rend;
    public AudioClip cannonShot;
    public CannonArea cannonArea; // 👈 ESTE ES EL LINK

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            rend.material.color = Color.green;

            Debug.Log("Botón presionado");

            if (SFXController.instance != null && cannonShot != null)
                SFXController.instance.PlaySFXAtPosition(cannonShot, transform.position);

            if (cannonArea != null)
            {
                cannonArea.tryShoot(); // 👈 AQUÍ SE DISPARA
            }
            else
            {
                Debug.Log("NO hay referencia a CannonArea");
            }
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