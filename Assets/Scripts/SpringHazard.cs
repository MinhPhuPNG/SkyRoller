using UnityEngine;

public class SpringHazard : MonoBehaviour
{
    public float bounceForce = 8f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 currentVelocity = rb.linearVelocity;
                currentVelocity.y = 0f;
                rb.linearVelocity = currentVelocity;

                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}