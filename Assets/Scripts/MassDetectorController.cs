using UnityEngine;

public class MassDetectorController : MonoBehaviour
{
    public GameObject glassDoor;

    bool isObject = false;

    void OnTriggerStay(Collider other)
    {
        isObject = true;

        Rigidbody rb = other.attachedRigidbody;

        if (rb == null)
        {
            Debug.Log("Hay algo, pero sin masa");
            glassDoor.SetActive(true);

            return;
        }

        if (rb.mass == 5f)
        {
            Debug.Log("Masa correcta");
            glassDoor.SetActive(false);
        }
        else if (rb.mass < 5f)
        {
            Debug.Log("Muy ligero");
            glassDoor.SetActive(true);
        }
        else
        {
            Debug.Log("Muy pesado");
            glassDoor.SetActive(true);
        }
    }

    void Update()
    {
        if (!isObject)
        {
            Debug.Log("No hay nada");
            glassDoor.SetActive(true);
        }


        isObject = false;
    }
}
