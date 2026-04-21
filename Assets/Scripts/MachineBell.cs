using UnityEngine;

public class MachineBell : MonoBehaviour
{
    public GameObject trapdoor;

    bool alreadyWon = false;

    void Start()
    {
        trapdoor.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (alreadyWon) return;

        if (other.transform.root.CompareTag("Ball"))
        {
            alreadyWon = true;
            Debug.Log("WIN");

            trapdoor.SetActive(false);
        }
    }
}
