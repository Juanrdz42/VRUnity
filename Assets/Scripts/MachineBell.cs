using UnityEngine;

public class MachineBell : MonoBehaviour
{
    bool alreadyWon = false;

    void OnTriggerEnter(Collider other)
    {
        if (alreadyWon) return;

        if (other.transform.root.CompareTag("Ball"))
        {
            alreadyWon = true;
            Debug.Log("WIN");
        }
    }
}
