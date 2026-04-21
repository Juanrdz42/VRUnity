using UnityEngine;

public class ForceButton : MonoBehaviour
{
    public Rigidbody ball;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.CompareTag("Hammer"))
        {
            float force = Vector3.Dot(collision.relativeVelocity, Vector3.up);
            force = Mathf.Clamp(force, 0, 20);

            Debug.Log("Force: " + force);

            if (force < 1f) return;

            float multiplier = 5f;

            ball.linearVelocity = Vector3.zero;
            ball.angularVelocity = Vector3.zero;

            ball.AddForce(Vector3.up * force * multiplier, ForceMode.Impulse);
        }
    }
}
