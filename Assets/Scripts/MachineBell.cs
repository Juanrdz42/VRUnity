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
        Debug.Log("Entró algo: " + other.name + " | tag: " + other.tag);

        if (alreadyWon) return;

        if (other.CompareTag("Ball"))
        {
            alreadyWon = true;
            Debug.Log("WIN");
            trapdoor.SetActive(false);
        }
    }
}