using UnityEngine;

public class ShowRiddle : MonoBehaviour
{
    public GameObject textRiddle; 

    void Start()
    {
        textRiddle.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textRiddle.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textRiddle.SetActive(false);
        }
    }
}
